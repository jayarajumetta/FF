param([string]$Path = "Path", [string]$FileNameUsed = "FileNameUsed", [string]$State = "State", [string]$QuoteID = "QuoteID")

#### Set the DebugMode to 1 if you want to use parameters below
$devDebugMode=0
$localDebugMode=0
if($localDebugMode)
{
$Path ="\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BAP\"
$FileNameUsed="BAP_BASICtest"  #file name to use for the excel doc with all expected results
$State="CO"
$QuoteID="777178"
}
       

$FileNameUsedOnPolicyRs = $FileNameUsed  #this will be used by the response file and results file.
$b = Get-Date
$startTime =$b
Write-Output "$b begin powershell "
# Build file name from the parameters passed

$PathAndFileNotExcel  =$Path + $FileNameUsed + ".csv" 
 Write-Output "$b Excel File with items to check is csv:  $PathAndFileNotExcel"

$FileNameUsedExtended = $FileNameUsed + "_"+ $State + "_"+ $QuoteID
 Write-Output "$b File name with state and quote id referenced in building csv and excel:   $FileNameUsedExtended"
$FileNameUsedExtendedWithPath = $Path + $FileNameUsedExtended
 Write-Output "$b Filename with path (used to tack on .csv or .xml or results.csv: "  $FileNameUsedExtendedWithPath

$PathAndFileCSV      = $FileNameUsedExtendedWithPath + ".CSV"
 Write-Output "$b CSV File the excel doc gets converted to: $PathAndFileCSV"
#this is for the list of forms that came back from the response.
$PathAndFileOnPolicy = $FileNameUsedExtendedWithPath + ".XML"
Write-Output "$b Location we are checking for the list of forms that come back from the response: $PathAndFileOnPolicy"
$PathAndFileResults = $FileNameUsedExtendedWithPath + "Results.CSV"
Write-Output "$b Location and name of final results file created: $PathAndFileResults"



 # if the csv file exists delete it
if (Test-Path $PathAndFileCSV) 
 {$b = Get-Date
    Write-Output "$b CSV file $PathAndFile already exists it will get deleted before trying to convert this excel doc to a new csv file"
     Remove-Item $PathAndFileCSV
     if (!(Test-Path $PathAndFileCSV)) 
     {$b = Get-Date
     Write-Output "$b CSV file deletion is complete"
     }
 }

 ####New trial using Import-Csv instead of Excel (IMPORTS THE EXPECTED RESULTS FILE ALREADY SAVED AS CSV AND THEN RENAMES IT TO REQUIRED PATH)
 $importeddata = Import-Csv $PathAndFileNotExcel
 $importeddata | Export-Csv $PathAndFileCSV -NoTypeInformation -Encoding UTF8
 
# load the xml file
[xml]$XmlDocument = Get-Content -Path $PathAndFileOnPolicy
$XMLFormsList = $XmlDocument.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc

 #This selected and then listed the form names and the status
#$XmlDocument.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc | Select-Object -Property name, selected

#load the csv file with the list of forms that need to be tested.
# load the data to an array list
if($devDebugMode)
{
Write-Output "$b BEGIN Load CSV file into an array "
}
$array = Import-Csv $PathAndFileCSV

#create a results array
$resultsArray = @()
#Create an object to populate the results table
$objTemplateObject = New-Object psobject
$objTemplateObject | Add-Member -MemberType NoteProperty -Name Form -Value $null
$objTemplateObject | Add-Member -MemberType NoteProperty -Name $State -Value $null
$objTemplateObject | Add-Member -MemberType NoteProperty -Name Results -Value $null
$objTemplateObject | Add-Member -MemberType NoteProperty -Name ResultsDetails -Value $null

#iterate through eachitem and see if it is in
if($devDebugMode)
{
Write-Output "$b BEGIN FORM ANALYSIS going through the array "
}
ForEach( $form in $array)
    {
    #assign each columns value a name
    $formName = $form.Form
    $AttachCondition = $form.$State.ToString()

    #Check if form is on policy. If so update the test results.
    #$result= ($XmlDocument.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc| Where {$_.name -eq $formName}).name
    $objTemp = $objTemplateObject | Select-Object *
    #lets now populate our custom properties that will get mapped to the result file
    $objTemp.Form = $form.Form
    $objTemp.$State = $AttachCondition
    $policyForm=($XmlDocument.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc| Where {$_.name -eq $formName}).name
    $policyFormSelected=($XmlDocument.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc| Where {$_.name -eq $formName}).selected
    #if forms names match then write out test results.
    if($devDebugMode)
        {
        Write-Output "$b About to start checking $policyForm "
    }
    if( $policyForm )
  {
    if ($AttachCondition -eq "YM" -and $policyFormSelected -eq 2)
            {
            $objTemp.ResultsDetails= "C1 PASS: Form $policyForm is Listed and checked"
            $objTemp.Results= "PASS"
            }
    elseif ( $AttachCondition -eq "YM" -and $policyFormSelected -eq 1)
            {
             $objTemp.ResultsDetails= "C2 PASS: Form $policyForm is Listed and checked (Not listed as MANDATORY)"
            $objTemp.Results= "PASS"          
            }
    elseif ( $AttachCondition -eq "YS" -and $policyFormSelected -eq 1)
            {
             $objTemp.ResultsDetails= "C3 PASS: Form $policyForm is Listed and Selected"
            $objTemp.Results= "PASS"          
            }
    elseif ( $AttachCondition -eq "YS" -and $policyFormSelected -eq 0)
            {
            $objTemp.ResultsDetails= "C4 FAIL: Form $policyForm is Listed and not checked"
            $objTemp.Results= "FAIL"          
            }
    elseif ( $AttachCondition -eq "N" -and $policyFormSelected -eq 2)
           {
            $objTemp.ResultsDetails= "C5 FAIL: Form $policyForm has $AttachCondition but is Listed and checked"  
           $objTemp.Results= "FAIL"          
           }
    elseif ($AttachCondition -eq "YM" -and $policyFormSelected -eq 0)
            {
            $objTemp.ResultsDetails= "C6 FAIL: Form $policyForm is Listed but not checked"
            $objTemp.Results= "FAIL"            
            }
    elseif ($AttachCondition -eq "N" -and $policyFormSelected -eq 0)
            {
            $objTemp.ResultsDetails= "C7 FAIL: Form $policyForm is Listed but not checked"  
            $objTemp.Results= "FAIL"          
            }
    elseif ($AttachCondition -eq "YU" -and $policyFormSelected -eq 0)
            {
            $objTemp.ResultsDetails= "C8 PASS: Form $policyForm is Listed and not checked"  
            $objTemp.Results= "PASS"          
            }
    elseif ($AttachCondition -eq "N" -and $policyFormSelected -eq 1)
            {
           $objTemp.ResultsDetails = "C9 FAIL: Form $policyForm has $AttachCondition but is Listed and checked (Not listed as MANDATORY)"
           $objTemp.Results= "FAIL"
            }
    else
            {
            $objTemp.ResultsDetails = "C10 ISSUE: CHECK $formName is listed but doesn't match a test scenario"
            $objTemp.Results= "ISSUE"
            }
 }
    elseif ($AttachCondition -eq "YM" )
                            {
            $objTemp.ResultsDetails = "C11 FAIL: Form $formName has $AttachCondition but is not listed"
            $objTemp.Results= "FAIL"
            }
    elseif ($AttachCondition -eq "YU" )
                            {
            $objTemp.ResultsDetails = "C11 FAIL: Form $formName has $AttachCondition but is not listed"
            $objTemp.Results= "FAIL"
            }
    elseif ($AttachCondition -eq "YS" )
                            {
            $objTemp.ResultsDetails = "C11 FAIL: Form $formName has $AttachCondition but is not listed"
            $objTemp.Results= "FAIL"
            }
    elseif ($AttachCondition -eq "N" )
                {
                $objTemp.ResultsDetails = "C12 PASS: Form $formName has $AttachCondition and is not listed"
                $objTemp.Results= "PASS"
                }
    else 
            {
            $objTemp.ResultsDetails = "C13 ISSUE: CHECK $formName is not listed and doesn't match test scenario"
            $objTemp.Results= "ISSUE"
    }
    
      # if($devDebugMode)
       # {
        #Write-Output $objTemp
        #Write-Output "Checked form name $policyForm  xml form name $formName results:" $objTemp.Results
        #Write-Output ($XmlDocument.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc| Where-Object {$XMLFormsList.name -eq $formName}).name
        #Write-Output "ResultsArray Count" $resultsArray.Count
       # }
    $resultsArray += $objTemp 
     }

if($devDebugMode)
{
Write-Output "$b END End of the for each  FORM ANALYSIS going through the array & begin non-listed forms analysis."
}
 #Add any forms that are in policy but not listed
  $count =0
  $objTempList = $resultsArray 

 ForEach( $PolicyForm in $XmlDocument.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc | Where {  -not ($objTempList.Form.Contains($_.name))})
 {
    $objTemp = $objTemplateObject | Select-Object *
    $objTemp.Form =  $PolicyForm.name
    $objTemp.Results = "INFO"
    If ($PolicyForm.selected -eq 2)
         {
         $objTemp.ResultsDetails = "C14 INFO: Form " +  $PolicyForm.name + " is not on test case but is listed & CHECKED on policy"
         }
    else 
         {
         $objTemp.ResultsDetails = "C15 INFO: Form " +  $PolicyForm.name + " is not on test case but is listed on policy"
         #$InfoForm
         }
    $count= $count +1
    $count
  $resultsArray += $objTemp 
 }
if($devDebugMode)
{
Write-Output "$b END non-listed forms analysis."
}

 $TotalPassed =0
 $TotalFailed = 0
 $TotalInfo =0
 $TotalFomrsListed=0
 $TotalOther=0
 ForEach ($item in $resultsArray)
 {
     if ($item.Results -eq "PASS"){
      $TotalPassed = $TotalPassed+1
      }
     elseif ($item.Results -eq "FAIL"){
      $TotalFailed = $TotalFailed+1
      }
      elseif ($item.Results -eq "INFO"){
      $TotalInfo = $TotalInfo+1
      }
      else {
      $TotalOther = $TotalOther+1
      if($devDebugMode)
            {
          Write-Output  $item
            }
      }
  $TotalFomrsListed=$TotalFomrsListed+1
 }

 $objTempT = $objTemplateObject | Select-Object *
 #$TotalPassed 
 #$TotalFailed 
 #$TotalInfo 
 #$TotalFomrsListed
  $objTempT.Form = "Total#Forms Listed:$TotalFomrsListed  Total PASS:$TotalPassed Total FAIL:$TotalFailed Total INFO:$TotalInfo Other: $TotalOther "
   $resultsArray += $objTempT 
#$resultsArray
 $resultsArray | Export-CSV $PathAndFileResults -Force
 Write-Output  $objTempT.Form


#Set-Clipboard -Value $objTempT.Form 

$objTempT.Form | C:\Windows\System32\clip.exe

#Clean up. Remove the XML File used to hold the forms
# if the xml file exists delete it
 if($devDebugMode -ne 1)
 {
    if (Test-Path $PathAndFileOnPolicy) 
     {
     $b = Get-Date
       Write-Output "$b end cleanup --XML file $PathAndFileOnPolicy IS BEING DELETED"
         Remove-Item $PathAndFileOnPolicy
         if (!(Test-Path $PathAndFileOnPolicy)) 
         { $b = Get-Date
         Write-Output "$b XML file deletion is complete"
         }
      }
    if (Test-Path $PathAndFileCSV) 
     {
     $b = Get-Date
       Write-Output "$b end cleanup --CSV file $PathAndFileCSV IS BEING DELETED"
         Remove-Item $PathAndFileCSV
         if (!(Test-Path $PathAndFileCSV)) 
         { $b = Get-Date
         Write-Output "$b CSV file deletion is complete"
         }
      }  
   }

  $b = Get-Date
  $endTime =$b
  $elapsedTime= $endTime -$startTime 
Write-Output "$b End Powershell script complete began at $startTime and ended at $endTime  =$elapsedTime"

