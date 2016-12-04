angular.module("app.services", ["ngResource"]).
       factory("ValuesService", function ($resource) {
    return $resource(
        "/api/Values/:id",
        { id: "@id" },
        {
            "update": { method: "PUT" },
            "save": {
                method: "POST", datatype: 'json',
                contentType: "application/x-www-form-urlencoded"
                //contentType: "application/json;charset=UTF-8"
            }
        }
   );
});