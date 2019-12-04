function searchFailed() {
    $("#searchresults").html("Sorry, there was a problem with the search.");
}


$(function () {
    $(".RemoveLink").click(function () {
        //alert("Link Clicked");

        
        var id = $(this).attr("data-id");

        $.post("/RegistrationCart/RemoveFromCart", { "id": id }, function (data) {

            $("#update-message").text(data.Message);
            $("#cart-total").text(data.CartTotal);
            $("#item-count-" + data.DeleteId).text(data.ItemCount);
            $("#item-status-" + data.DeleteId).text(data.status);
            

            //if (data.ItemCount < 1) {
            //    $("#record-" + data.DeleteId).fadeOut(); //will hide the item through animation
            //}

        });
        

    })
});