# Azure Event Grid

Azure Event Grid is an eventing backplane that enables event-driven, reactive programming. It uses the publish-subscribe model. Publishers emit events, but have no expectation about how the events are handled. Subscribers decide on which events they want to handle.

Event Grid allows you to easily build applications with event-based architectures. First, select the Azure resource you would like to subscribe to, and then give the event handler or WebHook endpoint to send the event to. Event Grid has built-in support for events coming from Azure services, like storage blobs and resource groups. Event Grid also has support for your own events, using custom topics.

You can use filters to route specific events to different endpoints, multicast to multiple endpoints, and make sure your events are reliably delivered.

This image below shows how Event Grid connects sources and handlers, and isn't a comprehensive list of supported integrations.

![image](https://user-images.githubusercontent.com/34960418/166907119-78fd0622-6006-48d5-9ea0-bab2c5e987e7.png)


# Concepts in Azure Event Grid

There are five concepts in Azure Event Grid you need to understand to help you get started, and are described in more detail below:

- Events - What happened.
- Event sources - Where the event took place.
- Topics - The endpoint where publishers send events.
- Event subscriptions - The endpoint or built-in mechanism to route events, sometimes to more than one handler. Subscriptions are also used by handlers to intelligently filter incoming events.
- Event handlers - The app or service reacting to the event.


# Events

An event is the smallest amount of information that fully describes something that happened in the system. Every event has common information like: source of the event, time the event took place, and unique identifier. Every event also has specific information that is only relevant to the specific type of event. For example, an event about a new file being created in Azure Storage has details about the file, such as the lastTimeModified value. Or, an Event Hubs event has the URL of the Capture file.

An event of size up to 64 KB is covered by General Availability (GA) Service Level Agreement (SLA). The support for an event of size up to 1 MB is currently in preview. Events over 64 KB are charged in 64-KB increments.


# Event sources

An event source is where the event happens. Each event source is related to one or more event types. For example, Azure Storage is the event source for blob created events. IoT Hub is the event source for device created events. Your application is the event source for custom events that you define. Event sources are responsible for sending events to Event Grid.


# Topics

The event grid topic provides an endpoint where the source sends events. The publisher creates the event grid topic, and decides whether an event source needs one topic or more than one topic. A topic is used for a collection of related events. To respond to certain types of events, subscribers decide which topics to subscribe to.

System topics are built-in topics provided by Azure services. You don't see system topics in your Azure subscription because the publisher owns the topics, but you can subscribe to them. To subscribe, you provide information about the resource you want to receive events from. As long as you have access to the resource, you can subscribe to its events.

Custom topics are application and third-party topics. When you create or are assigned access to a custom topic, you see that custom topic in your subscription.


# Event subscriptions

A subscription tells Event Grid which events on a topic you're interested in receiving. When creating the subscription, you provide an endpoint for handling the event. You can filter the events that are sent to the endpoint. You can filter by event type, or subject pattern. Set an expiration for event subscriptions that are only needed for a limited time and you don't want to worry about cleaning up those subscriptions.


# Event handlers

From an Event Grid perspective, an event handler is the place where the event is sent. The handler takes some further action to process the event. Event Grid supports several handler types. You can use a supported Azure service or your own webhook as the handler. Depending on the type of handler, Event Grid follows different mechanisms to guarantee the delivery of the event. For HTTP webhook event handlers, the event is retried until the handler returns a status code of 200 – OK. For Azure Storage Queue, the events are retried until the Queue service successfully processes the message push into the queue.


# Discover event schemas

Events consist of a set of four required string properties. The properties are common to all events from any publisher. The data object has properties that are specific to each publisher. For system topics, these properties are specific to the resource provider, such as Azure Storage or Azure Event Hubs.

Event sources send events to Azure Event Grid in an array, which can have several event objects. When posting events to an event grid topic, the array can have a total size of up to 1 MB. Each event in the array is limited to 1 MB. If an event or the array is greater than the size limits, you receive the response 413 Payload Too Large. Operations are charged in 64 KB increments though. So, events over 64 KB will incur operations charges as though they were multiple events. For example, an event that is 130 KB would incur operations as though it were 3 separate events.

Event Grid sends the events to subscribers in an array that has a single event. You can find the JSON schema for the Event Grid event and each Azure publisher's data payload in the [Event Schema store](https://github.com/Azure/azure-rest-api-specs/tree/master/specification/eventgrid/data-plane).1


# Event schema

The following example shows the properties that are used by all event publishers:

```json
[
  {
    "topic": string,
    "subject": string,
    "id": string,
    "eventType": string,
    "eventTime": string,
    "data":{
      object-unique-to-each-publisher
    },
    "dataVersion": string,
    "metadataVersion": string
  }
]
```


# Event properties

All events have the same following top-level data:

| Property        	| Type   	| Required                                                                                                                                              	| Description                                                                                                                          	|
|-----------------	|--------	|-------------------------------------------------------------------------------------------------------------------------------------------------------	|--------------------------------------------------------------------------------------------------------------------------------------	|
| topic           	| string 	| No. If not included, Event Grid will stamp onto the event. If included it must match the event grid topic Azure Resource Manager ID exactly.          	| Full resource path to the event source. This field isn't writeable. Event Grid provides this value.                                  	|
| subject         	| string 	| Yes                                                                                                                                                   	| Publisher-defined path to the event subject.                                                                                         	|
| eventType       	| string 	| Yes                                                                                                                                                   	| One of the registered event types for this event source.                                                                             	|
| eventTime       	| string 	| Yes                                                                                                                                                   	| The time the event is generated based on the provider's UTC time.                                                                    	|
| id              	| string 	| Yes                                                                                                                                                   	| Unique identifier for the event.                                                                                                     	|
| data            	| object 	| No                                                                                                                                                    	| Event data specific to the resource provider.                                                                                        	|
| dataVersion     	| string 	| No. If not included it will be stamped with an empty value.                                                                                           	| The schema version of the data object. The publisher defines the schema version.                                                     	|
| metadataVersion 	| string 	| No. If not included, Event Grid will stamp onto the event. If included, must match the Event Grid Schema metadataVersion exactly (currently, only 1). 	| The schema version of the event metadata. Event Grid defines the schema of the top-level properties. Event Grid provides this value. 	|

For custom topics, the event publisher determines the data object. The top-level data should have the same fields as standard resource-defined events.

When publishing events to custom topics, create subjects for your events that make it easy for subscribers to know whether they're interested in the event. Subscribers use the subject to filter and route events. Consider providing the path for where the event happened, so subscribers can filter by segments of that path. The path enables subscribers to narrowly or broadly filter events. For example, if you provide a three segment path like /A/B/C in the subject, subscribers can filter by the first segment /A to get a broad set of events. Those subscribers get events with subjects like /A/B/C or /A/D/E. Other subscribers can filter by /A/B to get a narrower set of events.

Sometimes your subject needs more detail about what happened. For example, the Storage Accounts publisher provides the subject ```/blobServices/default/containers/<container-name>/blobs/<file>``` when a file is added to a container. A subscriber could filter by the path /blobServices/default/containers/testcontainer to get all events for that container but not other containers in the storage account. A subscriber could also filter or route by the suffix .txt to only work with text files.


# CloudEvents v1.0 schema

In addition to its default event schema, Azure Event Grid natively supports events in the JSON implementation of CloudEvents v1.0 and HTTP protocol binding. CloudEvents is an open specification for describing event data.

CloudEvents simplifies interoperability by providing a common event schema for publishing, and consuming cloud based events. This schema allows for uniform tooling, standard ways of routing & handling events, and universal ways of deserializing the outer event schema. With a common schema, you can more easily integrate work across platforms.

Here is an example of an Azure Blob Storage event in CloudEvents format:

```json
{
    "specversion": "1.0",
    "type": "Microsoft.Storage.BlobCreated",  
    "source": "/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.Storage/storageAccounts/{storage-account}",
    "id": "9aeb0fdf-c01e-0131-0922-9eb54906e209",
    "time": "2019-11-18T15:13:39.4589254Z",
    "subject": "blobServices/default/containers/{storage-container}/blobs/{new-file}",
    "dataschema": "#",
    "data": {
        "api": "PutBlockList",
        "clientRequestId": "4c5dd7fb-2c48-4a27-bb30-5361b5de920a",
        "requestId": "9aeb0fdf-c01e-0131-0922-9eb549000000",
        "eTag": "0x8D76C39E4407333",
        "contentType": "image/png",
        "contentLength": 30699,
        "blobType": "BlockBlob",
        "url": "https://gridtesting.blob.core.windows.net/testcontainer/{new-file}",
        "sequencer": "000000000000000000000000000099240000000000c41c18",
        "storageDiagnostics": {
            "batchId": "681fe319-3006-00a8-0022-9e7cde000000"
        }
    }
}
```

A detailed description of the available fields, their types, and definitions in CloudEvents v1.0 is available here.

The headers values for events delivered in the CloudEvents schema and the Event Grid schema are the same except for content-type. For CloudEvents schema, that header value is "content-type":"application/cloudevents+json; charset=utf-8". For Event Grid schema, that header value is "content-type":"application/json; charset=utf-8".

You can use Event Grid for both input and output of events in CloudEvents schema. You can use CloudEvents for system events, like Blob Storage events and IoT Hub events, and custom events. It can also transform those events on the wire back and forth.
