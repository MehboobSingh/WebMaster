


function validerOgLagreBillet() {
    const fraOK = validerFra($("#fraInput").val());
    const tilOK = validerTil($("#tilInput").val());
    const datoFraOk = validerDato($("#datepicker").val());
    const returDatoOk = validerDato($("#datepicker2").val());
    const typeOk = $("#type").val();






    if (fraOK && tilOK && datoFraOk && returDatoOk && typeOk) {
        lagreBillet();
    }
}

function lagreBillet() {
    const billet = {
        fra: $("#fraInput").val(),
        til: $("#tilInput").val()
        reiseDato: $("#datepicker").val();
        returDato: $("#datepicker2").val();
        type: $("#type").val();

    }
    const url = "Home/lagreBillet";
    $.post(url, billet, function () {
        alert('suksess')
    })
        .fail(function () {
            $("#feil").html("Feil på server - prøv igjen senere");
        });
};


const validerButton = document.getElementById("checkout-button");
validerButton.addEventListener('click', validerOgLagreBillet())