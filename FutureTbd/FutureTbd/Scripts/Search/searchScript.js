
function SearchResultViewModel() {


    var self = this;


    self.clearList = function() {
        localStorage.setItem("compareList", {});
    };
    self.States = ko.observableArray([
   {
       "name": "Alabama",
       "abbreviation": "AL"
   },
   {
       "name": "Alaska",
       "abbreviation": "AK"
   },
   {
       "name": "American Samoa",
       "abbreviation": "AS"
   },
   {
       "name": "Arizona",
       "abbreviation": "AZ"
   },
   {
       "name": "Arkansas",
       "abbreviation": "AR"
   },
   {
       "name": "California",
       "abbreviation": "CA"
   },
   {
       "name": "Colorado",
       "abbreviation": "CO"
   },
   {
       "name": "Connecticut",
       "abbreviation": "CT"
   },
   {
       "name": "Delaware",
       "abbreviation": "DE"
   },
   {
       "name": "District Of Columbia",
       "abbreviation": "DC"
   },
   {
       "name": "Federated States Of Micronesia",
       "abbreviation": "FM"
   },
   {
       "name": "Florida",
       "abbreviation": "FL"
   },
   {
       "name": "Georgia",
       "abbreviation": "GA"
   },
   {
       "name": "Guam",
       "abbreviation": "GU"
   },
   {
       "name": "Hawaii",
       "abbreviation": "HI"
   },
   {
       "name": "Idaho",
       "abbreviation": "ID"
   },
   {
       "name": "Illinois",
       "abbreviation": "IL"
   },
   {
       "name": "Indiana",
       "abbreviation": "IN"
   },
   {
       "name": "Iowa",
       "abbreviation": "IA"
   },
   {
       "name": "Kansas",
       "abbreviation": "KS"
   },
   {
       "name": "Kentucky",
       "abbreviation": "KY"
   },
   {
       "name": "Louisiana",
       "abbreviation": "LA"
   },
   {
       "name": "Maine",
       "abbreviation": "ME"
   },
   {
       "name": "Marshall Islands",
       "abbreviation": "MH"
   },
   {
       "name": "Maryland",
       "abbreviation": "MD"
   },
   {
       "name": "Massachusetts",
       "abbreviation": "MA"
   },
   {
       "name": "Michigan",
       "abbreviation": "MI"
   },
   {
       "name": "Minnesota",
       "abbreviation": "MN"
   },
   {
       "name": "Mississippi",
       "abbreviation": "MS"
   },
   {
       "name": "Missouri",
       "abbreviation": "MO"
   },
   {
       "name": "Montana",
       "abbreviation": "MT"
   },
   {
       "name": "Nebraska",
       "abbreviation": "NE"
   },
   {
       "name": "Nevada",
       "abbreviation": "NV"
   },
   {
       "name": "New Hampshire",
       "abbreviation": "NH"
   },
   {
       "name": "New Jersey",
       "abbreviation": "NJ"
   },
   {
       "name": "New Mexico",
       "abbreviation": "NM"
   },
   {
       "name": "New York",
       "abbreviation": "NY"
   },
   {
       "name": "North Carolina",
       "abbreviation": "NC"
   },
   {
       "name": "North Dakota",
       "abbreviation": "ND"
   },
   {
       "name": "Northern Mariana Islands",
       "abbreviation": "MP"
   },
   {
       "name": "Ohio",
       "abbreviation": "OH"
   },
   {
       "name": "Oklahoma",
       "abbreviation": "OK"
   },
   {
       "name": "Oregon",
       "abbreviation": "OR"
   },
   {
       "name": "Palau",
       "abbreviation": "PW"
   },
   {
       "name": "Pennsylvania",
       "abbreviation": "PA"
   },
   {
       "name": "Puerto Rico",
       "abbreviation": "PR"
   },
   {
       "name": "Rhode Island",
       "abbreviation": "RI"
   },
   {
       "name": "South Carolina",
       "abbreviation": "SC"
   },
   {
       "name": "South Dakota",
       "abbreviation": "SD"
   },
   {
       "name": "Tennessee",
       "abbreviation": "TN"
   },
   {
       "name": "Texas",
       "abbreviation": "TX"
   },
   {
       "name": "Utah",
       "abbreviation": "UT"
   },
   {
       "name": "Vermont",
       "abbreviation": "VT"
   },
   {
       "name": "Virgin Islands",
       "abbreviation": "VI"
   },
   {
       "name": "Virginia",
       "abbreviation": "VA"
   },
   {
       "name": "Washington",
       "abbreviation": "WA"
   },
   {
       "name": "West Virginia",
       "abbreviation": "WV"
   },
   {
       "name": "Wisconsin",
       "abbreviation": "WI"
   },
   {
       "name": "Wyoming",
       "abbreviation": "WY"
   }
    ]);

    self.SelectedState = ko.observable(self.States[0]);

    self.SearchResultItems = ko.observableArray();
    self.TotalResults = ko.observable(0);

    self.ExecuteSearchByState = function() {


        var value = self.SelectedState().abbreviation;


        $.ajax({
            url: "/Search/ExecuteSearchByState",
            data: JSON.stringify({ 'state': value }),
            contentType: "application/json; charset=utf-8",
            type: "POST",
            success: function(result) {
                var jsonResult = JSON.parse(result.ResultString);

                self.SearchResultItems([]);
                $.each(jsonResult.results, function(key) {
                    self.SearchResultItems.push(new ResultItem(jsonResult.results[key]));
                });
                self.TotalResults(jsonResult.metadata.total);
            }
        });
    };
    self.ExecuteSearch = function() {
        var value = $("#searchInput").val();
        $.ajax({
            url: "/Search/ExecuteSearch",
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
            }
        });
    };

    self.addToCompareList = function(item) {
        // item.isInCompareList(true);

        item.isAdded(true);
        var oldSessionStorageObj = localStorage.getItem("compareList");
        var universities = ko.observableArray();
        item.maxDegree = item.highestDegree();
        item.years = item.numberOfYears();
        universities.push(item);
        if (oldSessionStorageObj != null && oldSessionStorageObj !== "") {
            var joldSessionStorageObj = JSON.parse(oldSessionStorageObj);
            $(joldSessionStorageObj).each(function(i) {
                universities.push(joldSessionStorageObj[i]);
            });
        }
        localStorage.setItem("compareList", JSON.stringify(universities()));

        //var addSign = $("#addToList" + item.id);
        //addSign.removeClass("glyphicon-plus");
        //addSign.addClass("glyphicon-minus");
    };

    self.removeFromCompareList = function(item) {

        var oldSessionStorageObj = localStorage.getItem("compareList");
        //   oldSessionStorageObj.remove(item);
        var universities = ko.observableArray();

        if (oldSessionStorageObj !== "") {
            var joldSessionStorageObj = JSON.parse(oldSessionStorageObj);
            $(joldSessionStorageObj).each(function(i) {
                if (joldSessionStorageObj[i].id !== item.id) {
                    universities.push(joldSessionStorageObj[i]);
                }
            });
        }


        localStorage.setItem("compareList", JSON.stringify(universities()));
        item.isAdded(false);
    };

    

}

ko.applyBindings(new SearchResultViewModel());

function ResultItem(result) {
    var self = this;
    self.id = result["id"];
    self.isAdded = ko.observable(false);
    self.Name = result["school.name"];
    self.admissionOverallRate = result["2014.admissions.admission_rate.overall"] === null ? "N/A" : (result["2014.admissions.admission_rate.overall"] * 100).toFixed(2) + " %";
    self.address = result["school.city"] + ", " + result["school.state"] + " " + result["school.zip"];
    self.size = result["2014.student.size"];
    self.inTution = result["2013.cost.tuition.in_state"] === null ? "N/A" : "$" + result["2013.cost.tuition.in_state"];
    self.outTution = result["2013.cost.tuition.out_of_state"] === null ? "N/A" : "$" + result["2013.cost.tuition.out_of_state"];
    self.avgCostOfAttendance = result["2013.cost.attendance.academic_year"] === null ? 0 : "$" + result["2013.cost.attendance.academic_year"];
    self.numberOfYears = ko.observable(4);

    self.ShowCalculator = function() {
        $(".calculator").accrue({
            mode: "amortization",
            default_values: {
                amount: "$" + (self.numberOfYears() * result["2013.cost.attendance.academic_year"]),
                rate: "6%",
                rate_compare: "100.49%",
                term: "10y"
            }
        });
        $(".accrue-amortization").addClass("table");
        $(".accrue-amortization").addClass("table-striped");


        $("#loanCalculator").modal();
    };

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


    self.isInCompareList = ko.computed(function() {
        var oldSessionStorageObj = localStorage.getItem("compareList");
        var exists = false;

        if (oldSessionStorageObj !== "") {
            var joldSessionStorageObj = JSON.parse(oldSessionStorageObj);
            $(joldSessionStorageObj).each(function(i) {
                if (joldSessionStorageObj[i].id === self.id) {
                    exists = true;
                }
            });
        }
        return exists || self.isAdded();
    });
}