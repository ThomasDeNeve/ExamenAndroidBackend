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

function showDetail(id)
{
    switch (id)
    {
        case 1:
            $("#bureelgelijkvloers1").toggle();
            $("#bureelgelijkvloers2").hide();
            $("#coworkgelijkvloers1").hide();

            break;
        case 2:
            $("#bureelgelijkvloers2").toggle();
            $("#bureelgelijkvloers1").hide();
            $("#coworkgelijkvloers1").hide();

            break;
        case 3:
            $("#coworkgelijkvloers1").toggle();
            $("#bureelgelijkvloers1").hide();
            $("#bureelgelijkvloers2").hide();
            break;
    }
}