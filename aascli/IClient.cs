﻿//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AAS.CLI
{
    public interface IClient
    {
        string BaseUrl { get; set; }

        string Token { get; set; }
        bool ReadResponseAsString { get; set; }

        Task<AssetAdministrationShell> AasGETAsync(string content);
        Task<AssetAdministrationShell> AasGETAsync(string content, CancellationToken cancellationToken);
        Task AasPUTAsync(string content, AssetAdministrationShell body);
        Task AasPUTAsync(string content, AssetAdministrationShell body, CancellationToken cancellationToken);
        Task<AssetInformation> AssetInformationGETAsync();
        Task<AssetInformation> AssetInformationGETAsync(CancellationToken cancellationToken);
        Task AssetInformationPUTAsync(AssetInformation body);
        Task AssetInformationPUTAsync(AssetInformation body, CancellationToken cancellationToken);
        Task<ICollection<ConceptDescription>> ConceptDescriptionsAllAsync(string idShort, string isCaseOf, string dataSpecificationRef);
        Task<ICollection<ConceptDescription>> ConceptDescriptionsAllAsync(string idShort, string isCaseOf, string dataSpecificationRef, CancellationToken cancellationToken);
        Task ConceptDescriptionsDELETEAsync(string cdIdentifier);
        Task ConceptDescriptionsDELETEAsync(string cdIdentifier, CancellationToken cancellationToken);
        Task<ConceptDescription> ConceptDescriptionsGETAsync(string cdIdentifier);
        Task<ConceptDescription> ConceptDescriptionsGETAsync(string cdIdentifier, CancellationToken cancellationToken);
        Task<ConceptDescription> ConceptDescriptionsPOSTAsync(ConceptDescription body);
        Task<ConceptDescription> ConceptDescriptionsPOSTAsync(ConceptDescription body, CancellationToken cancellationToken);
        Task ConceptDescriptionsPUTAsync(string cdIdentifier, ConceptDescription body);
        Task ConceptDescriptionsPUTAsync(string cdIdentifier, ConceptDescription body, CancellationToken cancellationToken);
        Task<ICollection<Descriptor>> DescriptorAsync();
        Task<ICollection<Descriptor>> DescriptorAsync(CancellationToken cancellationToken);
        Task<OperationResult> InvokeAsync(string idShortPath, bool? _async, string content, OperationRequest body);
        Task<OperationResult> InvokeAsync(string idShortPath, bool? _async, string content, OperationRequest body, CancellationToken cancellationToken);
        Task<OperationResult> OperationResultsAsync(string idShortPath, string handleId, string content);
        Task<OperationResult> OperationResultsAsync(string idShortPath, string handleId, string content, CancellationToken cancellationToken);
        Task<ICollection<PackageDescription>> PackagesAllAsync(string aasId);
        Task<ICollection<PackageDescription>> PackagesAllAsync(string aasId, CancellationToken cancellationToken);
        Task PackagesDELETEAsync(string packageId);
        Task PackagesDELETEAsync(string packageId, CancellationToken cancellationToken);
        Task<byte[]> PackagesGETAsync(string packageId);
        Task<byte[]> PackagesGETAsync(string packageId, CancellationToken cancellationToken);
        Task<PackageDescription> PackagesPOSTAsync(PackagesBody body);
        Task<PackageDescription> PackagesPOSTAsync(PackagesBody body, CancellationToken cancellationToken);
        Task<PackageDescription> PackagesPUTAsync(string packageId, PackagesBody body);
        Task<PackageDescription> PackagesPUTAsync(string packageId, PackagesBody body, CancellationToken cancellationToken);
        Task<byte[]> SerializationAsync(IEnumerable<string> aasIds, IEnumerable<string> submodelIds, bool includeConceptDescriptions);
        Task<byte[]> SerializationAsync(IEnumerable<string> aasIds, IEnumerable<string> submodelIds, bool includeConceptDescriptions, CancellationToken cancellationToken);
        Task<ICollection<AssetAdministrationShellDescriptor>> ShellDescriptorsAllAsync();
        Task<ICollection<AssetAdministrationShellDescriptor>> ShellDescriptorsAllAsync(CancellationToken cancellationToken);
        Task ShellDescriptorsDELETEAsync(string aasIdentifier);
        Task ShellDescriptorsDELETEAsync(string aasIdentifier, CancellationToken cancellationToken);
        Task<AssetAdministrationShellDescriptor> ShellDescriptorsGETAsync(string aasIdentifier);
        Task<AssetAdministrationShellDescriptor> ShellDescriptorsGETAsync(string aasIdentifier, CancellationToken cancellationToken);
        Task<AssetAdministrationShellDescriptor> ShellDescriptorsPOSTAsync(AssetAdministrationShellDescriptor body);
        Task<AssetAdministrationShellDescriptor> ShellDescriptorsPOSTAsync(AssetAdministrationShellDescriptor body, CancellationToken cancellationToken);
        Task ShellDescriptorsPUTAsync(string aasIdentifier, AssetAdministrationShellDescriptor body);
        Task ShellDescriptorsPUTAsync(string aasIdentifier, AssetAdministrationShellDescriptor body, CancellationToken cancellationToken);
        Task<ICollection<string>> ShellsAllGET2Async(IEnumerable<IdentifierKeyValuePair> assetIds);
        Task<ICollection<string>> ShellsAllGET2Async(IEnumerable<IdentifierKeyValuePair> assetIds, CancellationToken cancellationToken);
        Task<ICollection<AssetAdministrationShell>> ShellsAllGET3Async(IEnumerable<IdentifierKeyValuePair> assetIds, string idShort);
        Task<ICollection<AssetAdministrationShell>> ShellsAllGET3Async(IEnumerable<IdentifierKeyValuePair> assetIds, string idShort, CancellationToken cancellationToken);
        Task<ICollection<IdentifierKeyValuePair>> ShellsAllGETAsync(string aasIdentifier);
        Task<ICollection<IdentifierKeyValuePair>> ShellsAllGETAsync(string aasIdentifier, CancellationToken cancellationToken);
        Task<ICollection<IdentifierKeyValuePair>> ShellsAllPOSTAsync(string aasIdentifier, IEnumerable<IdentifierKeyValuePair> body);
        Task<ICollection<IdentifierKeyValuePair>> ShellsAllPOSTAsync(string aasIdentifier, IEnumerable<IdentifierKeyValuePair> body, CancellationToken cancellationToken);
        Task ShellsDELETE2Async(string aasIdentifier);
        Task ShellsDELETE2Async(string aasIdentifier, CancellationToken cancellationToken);
        Task ShellsDELETEAsync(string aasIdentifier);
        Task ShellsDELETEAsync(string aasIdentifier, CancellationToken cancellationToken);
        Task<AssetAdministrationShell> ShellsGETAsync(string aasIdentifier);
        Task<AssetAdministrationShell> ShellsGETAsync(string aasIdentifier, CancellationToken cancellationToken);
        Task<AssetAdministrationShell> ShellsPOSTAsync(AssetAdministrationShell body);
        Task<AssetAdministrationShell> ShellsPOSTAsync(AssetAdministrationShell body, CancellationToken cancellationToken);
        Task ShellsPUTAsync(string aasIdentifier, AssetAdministrationShell body);
        Task ShellsPUTAsync(string aasIdentifier, AssetAdministrationShell body, CancellationToken cancellationToken);
        Task<ICollection<SubmodelDescriptor>> SubmodelDescriptorsAll2Async();
        Task<ICollection<SubmodelDescriptor>> SubmodelDescriptorsAll2Async(CancellationToken cancellationToken);
        Task<ICollection<SubmodelDescriptor>> SubmodelDescriptorsAllAsync(string aasIdentifier);
        Task<ICollection<SubmodelDescriptor>> SubmodelDescriptorsAllAsync(string aasIdentifier, CancellationToken cancellationToken);
        Task SubmodelDescriptorsDELETE2Async(string submodelIdentifier);
        Task SubmodelDescriptorsDELETE2Async(string submodelIdentifier, CancellationToken cancellationToken);
        Task SubmodelDescriptorsDELETEAsync(string aasIdentifier, string submodelIdentifier);
        Task SubmodelDescriptorsDELETEAsync(string aasIdentifier, string submodelIdentifier, CancellationToken cancellationToken);
        Task<SubmodelDescriptor> SubmodelDescriptorsGET2Async(string submodelIdentifier);
        Task<SubmodelDescriptor> SubmodelDescriptorsGET2Async(string submodelIdentifier, CancellationToken cancellationToken);
        Task<SubmodelDescriptor> SubmodelDescriptorsGETAsync(string aasIdentifier, string submodelIdentifier);
        Task<SubmodelDescriptor> SubmodelDescriptorsGETAsync(string aasIdentifier, string submodelIdentifier, CancellationToken cancellationToken);
        Task<SubmodelDescriptor> SubmodelDescriptorsPOST2Async(SubmodelDescriptor body);
        Task<SubmodelDescriptor> SubmodelDescriptorsPOST2Async(SubmodelDescriptor body, CancellationToken cancellationToken);
        Task<SubmodelDescriptor> SubmodelDescriptorsPOSTAsync(string aasIdentifier, SubmodelDescriptor body);
        Task<SubmodelDescriptor> SubmodelDescriptorsPOSTAsync(string aasIdentifier, SubmodelDescriptor body, CancellationToken cancellationToken);
        Task SubmodelDescriptorsPUT2Async(string submodelIdentifier, SubmodelDescriptor body);
        Task SubmodelDescriptorsPUT2Async(string submodelIdentifier, SubmodelDescriptor body, CancellationToken cancellationToken);
        Task SubmodelDescriptorsPUTAsync(string aasIdentifier, string submodelIdentifier, SubmodelDescriptor body);
        Task SubmodelDescriptorsPUTAsync(string aasIdentifier, string submodelIdentifier, SubmodelDescriptor body, CancellationToken cancellationToken);
        Task<ICollection<SubmodelElement>> SubmodelElementsAllAsync(string level, string content, string extent);
        Task<ICollection<SubmodelElement>> SubmodelElementsAllAsync(string level, string content, string extent, CancellationToken cancellationToken);
        Task SubmodelElementsDELETEAsync(string idShortPath);
        Task SubmodelElementsDELETEAsync(string idShortPath, CancellationToken cancellationToken);
        Task<SubmodelElement> SubmodelElementsGETAsync(string idShortPath, string level, string content, string extent);
        Task<SubmodelElement> SubmodelElementsGETAsync(string idShortPath, string level, string content, string extent, CancellationToken cancellationToken);
        Task<SubmodelElement> SubmodelElementsPOST2Async(string level, string content, string extent, SubmodelElement body);
        Task<SubmodelElement> SubmodelElementsPOST2Async(string level, string content, string extent, SubmodelElement body, CancellationToken cancellationToken);
        Task<SubmodelElement> SubmodelElementsPOSTAsync(string idShortPath, string level, string content, string extent, SubmodelElement body);
        Task<SubmodelElement> SubmodelElementsPOSTAsync(string idShortPath, string level, string content, string extent, SubmodelElement body, CancellationToken cancellationToken);
        Task SubmodelElementsPUTAsync(string idShortPath, string level, string content, string extent, SubmodelElement body);
        Task SubmodelElementsPUTAsync(string idShortPath, string level, string content, string extent, SubmodelElement body, CancellationToken cancellationToken);
        Task<Submodel> SubmodelGETAsync(string level, string content, string extent);
        Task<Submodel> SubmodelGETAsync(string level, string content, string extent, CancellationToken cancellationToken);
        Task SubmodelPUTAsync(string level, string content, string extent, Submodel body);
        Task SubmodelPUTAsync(string level, string content, string extent, Submodel body, CancellationToken cancellationToken);
        Task<ICollection<Submodel>> SubmodelsAll2Async(string semanticId, string idShort);
        Task<ICollection<Submodel>> SubmodelsAll2Async(string semanticId, string idShort, CancellationToken cancellationToken);
        Task<ICollection<Reference>> SubmodelsAllAsync();
        Task<ICollection<Reference>> SubmodelsAllAsync(CancellationToken cancellationToken);
        Task SubmodelsDELETE2Async(string submodelIdentifier);
        Task SubmodelsDELETE2Async(string submodelIdentifier, CancellationToken cancellationToken);
        Task SubmodelsDELETEAsync(string submodelIdentifier);
        Task SubmodelsDELETEAsync(string submodelIdentifier, CancellationToken cancellationToken);
        Task<Submodel> SubmodelsGETAsync(string submodelIdentifier);
        Task<Submodel> SubmodelsGETAsync(string submodelIdentifier, CancellationToken cancellationToken);
        Task<Submodel> SubmodelsPOST2Async(Submodel body);
        Task<Submodel> SubmodelsPOST2Async(Submodel body, CancellationToken cancellationToken);
        Task<Reference> SubmodelsPOSTAsync(Reference body);
        Task<Reference> SubmodelsPOSTAsync(Reference body, CancellationToken cancellationToken);
        Task<Submodel> SubmodelsPUTAsync(string submodelIdentifier, Submodel body);
        Task<Submodel> SubmodelsPUTAsync(string submodelIdentifier, Submodel body, CancellationToken cancellationToken);
    }
}