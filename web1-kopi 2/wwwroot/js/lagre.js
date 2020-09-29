

function validerOgLagreStrekning() {
    const fraOK = validerFra($("#fra").val());
    const tilOK = validerTil($("#til").val());
   
    if (fraOK && tilOK) {
        lagreStrekning();
    }
}

function lagreStrekning() {
    const strekning = {
        fra: $("#fra").val(),
        til: $("#til").val(),
        
    }
    const url = "Home/lagreStrekning";
    $.post(url, strekning, function () {
        window.location.href = 'index.html';
    })
    .fail(function () {
        $("#feil").html("Feil på server - prøv igjen senere");
    });
};