



//test for all my functions
function searchBox1() {
    //Give values of search boxes to variables to work with in search function!
    var searchEvent = document.getElementById("searchEventBox").value;
    var searchLocation = document.getElementById("searchLocationBox").value;

    //window.alert("Value in search box 1 is: " + searchEvent); 
    /*
    if (searchEvent == "" && searchLocation == "") {
        document.getElementById("searchError").innerHTML = "You did not enter any values in the search boxes!";
    } */

}

function searchFailed()
{
    $("#searchresults").html("No results found.");

}