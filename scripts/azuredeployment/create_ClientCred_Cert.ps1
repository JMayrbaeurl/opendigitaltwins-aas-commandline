# Create self-signed certificate and export pfx and cer files

# please be aware that running this script will create a new cert each time in your certificate store.  If you need to rerun it, I recommend deleting the previous certs first in the store.

param(
	$tenant_id = 'aas-commandline',
	[Parameter(Mandatory=$true)]$client_id, 
	$FilePath = 'C:\Users\' + $env:UserName + '\OneDrive - Microsoft\Documents\Certs\',
	$StoreLocation = 'CurrentUser',
	$expirationYears = 1
)

if (-not(Test-Path $FilePath)) {
	New-Item $FilePath -ItemType Directory
}

$SubjectName = $tenant_id + '.' + $client_id
$cert_password = $client_id

$pfxFileName = $SubjectName + '.pfx'
$cerFileName = $SubjectName + '.cer'

$PfxFilePath = $FilePath + $pfxFileName
$CerFilePath = $FilePath + $cerFileName

$CertBeginDate = Get-Date
$CertExpiryDate = $CertBeginDate.AddYears($expirationYears)
$SecStringPw = ConvertTo-SecureString -String $cert_password -Force -AsPlainText 
$Cert = New-SelfSignedCertificate -DnsName $SubjectName -CertStoreLocation "cert:\$StoreLocation\My" -NotBefore $CertBeginDate -NotAfter $CertExpiryDate -KeySpec Signature
Export-PfxCertificate -cert $Cert -FilePath $PFXFilePath -Password $SecStringPw 
Export-Certificate -cert $Cert -FilePath $CerFilePath