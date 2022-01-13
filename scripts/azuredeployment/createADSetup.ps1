param($appRegName = 'aas-commandline',$apiAppname = 'aas-apisample-service')

# Create App registration for Command line app
$clientID=$(az ad app create --display-name $appRegName --query appId -o tsv)
# Add a client secret
$clientSecret=$(az ad app credential reset --id $clientID --append --query password -o tsv)

# Add permission for AAS REST API
# Get the Client id of the AAS API REST Service
$apiClientId=$(az ad app list --filter "displayname eq '$apiAppname'" --query "[0].appId" -o tsv)
# Now let us find the role id with the value ''
$appRoles=$(az ad sp show --id $apiClientId --query appRoles) | ConvertFrom-Json
foreach ($role in $appRoles)
{
	if ($role.value = " AAS.ReadWrite")
	{
		az ad app permission add --id $clientID --api $apiClientId --api-permissions $role.id=Role
		break
	}
}

Write-Output "Client ID:" $clientID
Write-Output "Client Secret:" $clientSecret
Write-Output "Scope": $$apiClientId