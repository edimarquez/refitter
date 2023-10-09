# .Refitter File format

The following is an example `.refitter` file

```js
{
  "openApiPath": "/path/to/your/openAPI", // Required
  "namespace": "Org.System.Service.Api.GeneratedCode", // Optional. Default=GeneratedCode
  "naming": {
    "useOpenApiTitle": false, // Optional. Default=true
    "interfaceName": "MyApiClient" // Optional. Default=ApiClient
  },
  "generateContracts": true, // Optional. Default=true
  "generateXmlDocCodeComments": true, // Optional. Default=true
  "addAutoGeneratedHeader": true, // Optional. Default=true
  "addAcceptHeaders": true, // Optional. Default=true
  "returnIApiResponse": false, // Optional. Default=false
  "generateOperationHeaders": true, // Optional. Default=true
  "typeAccessibility": "Public", // Optional. Values=Public|Internal. Default=Public
  "useCancellationTokens": false, // Optional. Default=false
  "useIsoDateFormat": false, // Optional. Default=false
  "multipleInterfaces": "ByEndpoint", // Optional. May be one of "ByEndpoint" or "ByTag"
  "generateDeprecatedOperations": false, // Optional. Default=true
  "operationNameTemplate": "{operationName}Async", // Optional. Must contain {operationName}
  "optionalParameters": false, // Optional. Default=false
  "outputFolder": "../CustomOutput" // Optional. Default=./Generated
  "additionalNamespaces": [ // Optional
    "Namespace1",
    "Namespace2"
  ],
  "includeTags": [ // Optional. OpenAPI Tag to include when generating code
    "Pet",
    "Store",
    "User"
  ],
  "includePathMatches": [ // Optional. Only include Paths that match the provided regular expression
    "^/pet/.*",
    "^/store/.*"
  ],
  "dependencyInjectionSettings": {
    "baseUrl": "https://petstore3.swagger.io/api/v3", // Optional. Leave this blank to set the base address manually
    "httpMessageHandlers": [ // Optional
        "AuthorizationMessageHandler", 
        "TelemetryMessageHandler" 
    ],
    "usePolly": true, // Optional. Set this to true, to configure Polly with a retry policy that uses a jittered backoff. Default=false
    "pollyMaxRetryCount": 3, // Optional. Default=6
    "firstBackoffRetryInSeconds": 0.5 // Optional. Default=1.0
  }
}
```

- `openApiPath` - points to the OpenAPI Specifications file. This can be the path to a file stored on disk, relative to the `.refitter` file. This can also be a URL to a remote file that will be downloaded over HTTP/HTTPS
- `namespace` - the namespace used in the generated code. If not specified, this defaults to `GeneratedCode`
- `naming.useOpenApiTitle` - a boolean indicating whether the OpenApi title should be used. Default is `true`
- `naming.interfaceName` - the name of the generated interface. The generated code will automatically prefix this with `I` so if this set to `MyApiClient` then the generated interface is called `IMyApiClient`. Default is `ApiClient`
- `generateContracts` - a boolean indicating whether contracts should be generated. A use case for this is several API clients use the same contracts. Default is `true`
- `generateXmlDocCodeComments` - a boolean indicating whether XML doc comments should be generated. Default is `true`
- `addAutoGeneratedHeader` - a boolean indicating whether XML doc comments should be generated. Default is `true`
- `addAcceptHeaders` -  a boolean indicating whether to add accept headers [Headers("Accept: application/json")]. Default is `true`
- `returnIApiResponse` - a boolean indicating whether to return `IApiResponse<T>` objects. Default is `false`
- `generateOperationHeaders` - a boolean indicating whether to use operation headers in the generated methods. Default is `true`
- `typeAccessibility` - the generated type accessibility. Possible values are `Public` and `Internal`. Default is `Public`
- `useCancellationTokens` - Use cancellation tokens in the generated methods. Default is `false`
- `useIsoDateFormat` - Set to `true` to explicitly format date query string parameters in ISO 8601 standard date format using delimiters (for example: 2023-06-15). Default is `false`
- `multipleInterfaces` - Set to `ByEndpoint` to generate an interface for each endpoint, or `ByTag` to group Endpoints by their Tag (like SwaggerUI groups them).
- `outputFolder` - a string describing a relative path to a desired output folder. Default is `./Generated`
- `additionalNamespaces` - A collection of additional namespaces to include in the generated file. A use case for this is when you want to reuse contracts from a different namespace than the generated code. Default is empty
- `includeTags` - A collection of tags to use a filter for including endpoints that contain this tag.
- `includePathMatches` - A collection of regular expressions used to filter paths.
- `generateDeprecatedOperations` - a boolean indicating whether deprecated operations should be generated or skipped. Default is `true`
- `operationNameTemplate` - Generate operation names using pattern. This must contain the string {operationName}. An example usage of this could be `{operationName}Async` to suffix all method names with Async
- `optionalParameters` - Generate non-required parameters as nullable optional parameters
- `dependencyInjectionSettings` - Setting this will generated extension methods to `IServiceCollection` for configuring Refit clients
  - `baseUrl` - Used as the HttpClient base address. Leave this blank to manually set the base URL
  - `httpMessageHandlers` - A collection of `HttpMessageHandler` that is added to the HttpClient pipeline
  - `usePolly` - Set this to true to configure the HttpClient to use Polly using a retry policy with a jittered backoff
  - `pollyMaxRetryCount` - This is the max retry count used in the Polly retry policy. Default is 6
  - `firstBackoffRetryInSeconds` - This is the duration of the initial retry backoff. Default is 1 second