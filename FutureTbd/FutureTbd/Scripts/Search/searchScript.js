
function SearchResultViewModel() {


    var self = this;


    self.clearList = function() {
        localStorage.setItem("compareList", {});
    };


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
                //console.log(result);
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