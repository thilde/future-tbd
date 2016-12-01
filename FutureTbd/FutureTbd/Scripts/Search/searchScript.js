﻿
function SearchResultViewModel() {
    var self = this;
    self.SearchResultItems = ko.observableArray();
    self.TotalResults = ko.observable(0);

    self.ExecuteSearch = function() {
        var value = $("#searchInput").val();
        $.ajax({
            url: "Search/ExecuteSearch",
            data: JSON.stringify({ 'searchText': value }),
            contentType: "application/json; charset=utf-8",
            type: "POST",
            success: function(result) {
                var jsonResult = JSON.parse(result.ResultString);

                self.SearchResultItems([]);
                $.each(jsonResult.results, function(key) {
                    self.SearchResultItems.push(new ResultItem(jsonResult.results[key]));
                });
                self.TotalResults(jsonResult.metadata.total);
                console.log(result);
            }
        });
    };
}

ko.applyBindings(new SearchResultViewModel());

function ResultItem(result) {
    var self = this;
    self.Name = result["school.name"];
    self.admissionOverallRate = result["2014.admissions.admission_rate.overall"] === null ? "N/A" : (result["2014.admissions.admission_rate.overall"] * 100).toFixed(2) + " %";
    self.address = result["school.city"] + ", " + result["school.state"] + " " + result["school.zip"];
    self.size = result["2014.student.size"];
    self.inTution = result["2013.cost.tuition.in_state"] === null ? 'N/A' :'$'+ result["2013.cost.tuition.in_state"];
    self.outTution = result["2013.cost.tuition.out_of_state"] === null ? 'N/A' : '$' + result["2013.cost.tuition.out_of_state"];




    self.highestDegree = ko.computed(function() {
        var degree = result["school.degrees_awarded.highest"];
        if (degree === 1) {
            return "Certificate";
        } else if (degree === 2) {
            return "Associate";
        } else if (degree === 3) {
            return "Bachelor's";
        } else if (degree === 4) {
            return "Graduate";
        } else {
            return "N/A";
        }
    });
}