$(function () {
     const id = window.location.search.substring(1);
    const url = "Home/hentEnStrekning?" + SId;
    $.get(url, function (strekning) {
        $("#SId").val(strekning.SId); 
        $("#fra").val(strekning.fra);
        $("#til").val(strekning.til);
       
    }); 
});

function validerOgEndreStrekning() {
    const fraOK = validerFra($("#fra").val());
    const tilOK = validerTil($("#til").val());
    
    if (fraOK && tilOK) {
        endreStrekning();
    }
}

function endreStrekning() {
    const strekning = {
        SId: $("#SId").val(), 
        fra: $("#fra").val(),
        til: $("#til").val(),
        
    };
    $.post("Home/endreStrekning", strekning, function () {
        window.location.href = 'index.html';
    })
    .fail(function () {
        $("#feil").html("Feil på server - prøv igjen senere");
    });
}