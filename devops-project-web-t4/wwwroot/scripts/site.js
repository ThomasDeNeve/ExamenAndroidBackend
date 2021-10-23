function showMessage(id)
{
    showDetails(id);
}

function showDetails(id)
{
    var newDiv = $("<div>Hovered over seat " + id + "</div>");
    console.log("Hovering over seat " + id);
    newDiv.addClass("box");

    //$("#details div").replaceAll(newDiv);
    $("#details").append(newDiv);
}

function hideMessage()
{
    $("#details").empty();
}