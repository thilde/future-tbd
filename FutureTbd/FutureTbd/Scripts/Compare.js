

function CompareViewModel() {
    var self = this;

    self.compareList = ko.observableArray();
    var oldSessionStorageObj = localStorage.getItem("compareList");
    if (oldSessionStorageObj != null && oldSessionStorageObj !== "") {
        var items = JSON.parse(oldSessionStorageObj);

        $.each(items, function(key) {

            self.compareList.push(new CompareItem(items[key]));

        });
    }

     self.remove = function (item) {
       
        //   oldSessionStorageObj.remove(item);
        var universities = ko.observableArray();

        if (oldSessionStorageObj !== "") {
            var joldSessionStorageObj = JSON.parse(oldSessionStorageObj);
            $(joldSessionStorageObj).each(function (i) {
                if (joldSessionStorageObj[i].id !== item.item.id) {
                    universities.push(joldSessionStorageObj[i]);
                }
            });
        }
         self.compareList.remove(item);

        localStorage.setItem("compareList", JSON.stringify(universities()));

    };


}

ko.applyBindings(new CompareViewModel());

function CompareItem(item) {
    var self = this;
    self.item = item;

    self.ShowCalculator = function() {
        $(".calculator").accrue({
            mode: "amortization",
            default_values: {
                amount: (item.years * item.avgCostOfAttendance.replace("$","")),
                rate: "6%",
                rate_compare: "100.49%",
                term: "10y"
            }
        });
        $(".accrue-amortization").addClass("table");
        $(".accrue-amortization").addClass("table-striped");


        $("#loanCalculator").modal();
    };

   

}