namespace OpenAqAirQuality.Tests.Unit.Services
{
    public static class OpenAqJsonOutputs
    {
        public const string LatestMeasurements = """
            {
              "meta": {
                "name": "openaq-api",
                "license": "CC BY 4.0d",
                "website": "api.openaq.org",
                "page": 1,
                "limit": 100,
                "found": 1
              },
              "results": [
                {
                  "location": "10920 Canyon RD",
                  "city": null,
                  "country": "US",
                  "coordinates": {
                    "latitude": 41.359016,
                    "longitude": -95.96844
                  },
                  "measurements": [
                    {
                      "parameter": "pm1",
                      "value": 24.8,
                      "lastUpdated": "2022-11-14T15:59:11+00:00",
                      "unit": "µg/m³"
                    },
                    {
                      "parameter": "pm25",
                      "value": 28.8,
                      "lastUpdated": "2022-11-14T15:59:11+00:00",
                      "unit": "µg/m³"
                    },
                    {
                      "parameter": "um100",
                      "value": 0,
                      "lastUpdated": "2022-11-14T15:59:11+00:00",
                      "unit": "particles/cm³"
                    },
                    {
                      "parameter": "um025",
                      "value": 0.04,
                      "lastUpdated": "2022-11-14T15:59:11+00:00",
                      "unit": "particles/cm³"
                    },
                    {
                      "parameter": "um010",
                      "value": 0.39,
                      "lastUpdated": "2022-11-14T15:59:11+00:00",
                      "unit": "particles/cm³"
                    },
                    {
                      "parameter": "pm10",
                      "value": 33.1,
                      "lastUpdated": "2022-11-14T15:59:11+00:00",
                      "unit": "µg/m³"
                    }
                  ]
                }
              ]
            }
            """;

        public const string Cities = """
            {
              "meta": {
                "name": "openaq-api",
                "license": "CC BY 4.0d",
                "website": "api.openaq.org",
                "page": 1,
                "limit": 1,
                "found": 3226
              },
              "results": [
                {
                  "country": "US",
                  "city": "007",
                  "count": 38685,
                  "locations": 7,
                  "firstUpdated": "2018-08-09T09:00:00+00:00",
                  "lastUpdated": "2022-11-14T14:00:00+00:00",
                  "parameters": [
                    "pm25"
                  ]
                }
              ]
            }
            """;

        public const string Location = """
            {
            	"meta": {
            		"name": "openaq-api",
            		"license": "CC BY 4.0d",
            		"website": "api.openaq.org",
            		"page": 1,
            		"limit": 100,
            		"found": 1
            	},
            	"results": [
            		{
            			"id": 67086,
            			"city": null,
            			"name": "10920 Canyon RD",
            			"entity": "community",
            			"country": "US",
            			"sources": [
            				{
            					"url": "https://www2.purpleair.com/",
            					"name": "PurpleAir",
            					"id": "purpleair",
            					"readme": null,
            					"organization": null,
            					"lifecycle_stage": null
            				}
            			],
            			"isMobile": false,
            			"isAnalysis": false,
            			"parameters": [
            				{
            					"id": 406548,
            					"unit": "µg/m³",
            					"count": 976905,
            					"average": 12.0852942711932,
            					"lastValue": 24.8,
            					"parameter": "pm1",
            					"displayName": "PM1",
            					"lastUpdated": "2022-11-14T15:59:11+00:00",
            					"parameterId": 19,
            					"firstUpdated": "2021-01-13T22:36:40+00:00",
            					"manufacturers": null
            				}
            			],
            			"sensorType": "low-cost sensor",
            			"coordinates": {
            				"latitude": 41.359016,
            				"longitude": -95.96844
            			},
            			"lastUpdated": "2022-11-14T15:59:11+00:00",
            			"firstUpdated": "2021-01-13T22:36:40+00:00",
            			"measurements": 5861334,
            			"bounds": null,
            			"manufacturers": null
            		}
            	]
            }
            """;
    }
}
