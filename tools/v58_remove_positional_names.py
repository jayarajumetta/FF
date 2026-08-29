from pathlib import Path
import json,re
root=Path(__file__).resolve().parents[1]
renames={
 'ClientSearch':{
  'Address':'NamedInsuredAddress',
  'AdditionalInsuredIndividualAddress1':'AdditionalInsuredIndividualAddress',
  'AddAssociatedClientAddress1':'AddAssociatedClientAddress',
  'Address2':'NamedInsuredAddressLineTwo',
 },
 'LossHistory':{'Address1':'LossAddress'},
 'Navigation':{
  'AdditionalOtherInterestInputAddress1':'AdditionalOtherInterestAddress',
  'CG2935AddLInsuredStateOrPoliticalPermitsAddress1':'CG2935AddLInsuredStateOrPoliticalPermitsAddress',
  'GLOCPRiskAddress1':'GLOCPRiskAddress',
  'LocationAddress1':'LocationAddress',
  'EndorsementScheduleRow1':'FirstEndorsementScheduleRow',
  'EndorsementTableRow1':'FirstEndorsementTableRow',
  'EndorsementTableRow2':'SecondEndorsementTableRow',
  'HiredAutoCA2001Address1':'HiredAutoCA2001Address',
 },
 'PolicyWorkflow':{'TheBrowserWasUnableToCommunicateWithTheServerHTTPStatusErrorHTTPStatus0':'BrowserCommunicationHTTPStatusZero'},
 'Coverages':{'FG0055TableRowFG0055':'FGFormTableRow'},
}
# locator files and page files: replace identifiers globally by descending length
for page,mp in renames.items():
    files=[root/f'tests/CommercialLines.DuckCreek.Tests/Pages/Locators/{page}Locators.cs',root/f'tests/CommercialLines.DuckCreek.Tests/Pages/{page}Page.cs']
    for f in files:
        s=f.read_text()
        for old,new in sorted(mp.items(),key=lambda x:-len(x[0])):
            s=re.sub(rf'\b{re.escape(old)}\b',new,s)
        f.write_text(s)
# step defs use method tokens which include locator identifier; replace within tokens/text only identifier string globally
for f in (root/'tests/CommercialLines.DuckCreek.Tests/StepDefinitions').glob('*.cs'):
    s=f.read_text()
    for mp in renames.values():
        for old,new in sorted(mp.items(),key=lambda x:-len(x[0])):
            s=s.replace(old,new)
    f.write_text(s)
# fallback catalog
cat=root/'Artifacts/LocatorFallbackCatalogs/CommercialLines.DuckCreek.json'
d=json.loads(cat.read_text())
for c in d['controls']:
    page=c.get('page',''); mp=renames.get(page,{})
    if c.get('control') in mp: c['control']=mp[c['control']]
    if c.get('canonicalControl') in mp: c['canonicalControl']=mp[c['canonicalControl']]
    if c.get('aliasOf') in mp: c['aliasOf']=mp[c['aliasOf']]
cat.write_text(json.dumps(d,indent=2)+'\n')
(root/'Artifacts/V58BusinessNameRefactor.json').write_text(json.dumps(renames,indent=2)+'\n')
print(sum(len(x) for x in renames.values()),'positional/generated API names renamed')
