# Open Digital Twins - Asset Administration Shell - Command line

Work in progress. Sample command line daemon application that can call [AAS API Rest servers](https://github.com/JMayrbaeurl/opendigitaltwins-aas-azureservices)

## Configuration

Application settings are stored in the local file 'appsettings.json' that's located in the application's folder.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft": "Warning",
      "AAS.CLI": "Information"
    },
    "Debug": {
      "LogLevel": {
        "Default": "Information",
        "AAS.CLI": "Trace"
      }
    }
  },
  "ClientId": "Enter here",
  "ClientSecret": "Enter here",
  "Authority": "Enter here",
  "Scope":  "Enter here"
}
```

### Security configuration
AAS REST API Servers are expecting a JWT Bearer token in the Authorization header of HTTP requests. Azure AD is used to 
generate these tokens. Therefore an App registration for the AAS command line app with the appropriate access permissions 
has to be created. See Powershell script 'createADSetup.ps1' in folder './scripts/azuredeployment'. The script outputs the 
Client Id, the Client secret and the Scope for the application settings file. Authority looks like
 `https://login.microsoftonline.com/[your directory tenant id]`

## AASX File Server support

**Basic usage**
```
aascli file subcommand [options]
```

### Operation GetAllAASXPackageIds**

Returns a list of available AASX packages at the server

```
aascli file list-all --aasId
```
**Examples**

Return all available AASX packages
```
aascli file list-all
```

Return all AASX packages that match the specified AAS identifier aasId
```
aascli file list-all --aasId '{aasId}'
```
**Required Parameters**

None

**Optional Parameters**

`--aasId -i`

AAS Ids which all must be in each matching AASX package