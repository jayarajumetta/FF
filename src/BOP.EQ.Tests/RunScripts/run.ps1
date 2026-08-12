param([string]$Filter='')
$arg = if ($Filter) { @('--filter',$Filter) } else { @() }
dotnet test -c Release --no-build --logger 'trx;LogFileName=results.trx' @arg
