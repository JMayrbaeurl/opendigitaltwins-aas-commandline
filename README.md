# Open Digital Twins - Asset Administration Shell - Command line

Work in progress. Sample command line daemon application that can call [AAS API Rest servers](https://github.com/JMayrbaeurl/opendigitaltwins-aas-azureservices)

## Configuration

### Security configuration
TBD. Azure AD App registration setup

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