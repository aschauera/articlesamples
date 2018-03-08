#load "distanceCalculator.csx"
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");
    try{
        // Get request body
        dynamic data = await req.Content.ReadAsAsync<object>();
        double latProject = data.latProject;
        double longProject = data.longProject;

        //Fake home coordinates
        double homeLat = 50.047691;
        double homeLong = 14.454320;

        var distance = 
            DistanceCalculator.GetDistanceBetweenPoints(latProject, longProject, homeLat, homeLong);
        
        
        return req.CreateResponse(HttpStatusCode.OK,new{ 
            message = string.Format("Reported issue is {0} km away, estimated logistics cost: € {1}",distance, 0),
            distance = distance,
            cost = 0
        });

    }catch(Exception ex){
        return req.CreateResponse(HttpStatusCode.BadRequest,new{
            message = ex.Message
        });
    }
}
