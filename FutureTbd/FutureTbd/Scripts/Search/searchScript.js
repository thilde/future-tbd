
    $(function () {
        $("#searchLink").click(function() {
            var value = $("#searchInput").val();
            $.ajax({
                url: "Search/ExecuteSearch",
                data: JSON.stringify({ 'searchText': value }),
                contentType: "application/json; charset=utf-8",
                type: "POST",
                success: function(result) {
                    console.log("success");
                }
            });
        });
            
     
    });