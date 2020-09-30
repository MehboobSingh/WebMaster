/*const fraInput = document.getElementById("fraInput")
const datoType = document.getElementById("datoType");
const checkbox = document.getElementById('myCheck');
const checkout = document.getElementById('checkout-button');


*/


function validerFraogTiltur(fra) {
    var regexp = /^[a-zA-Z ÆØÅæøå ]{2,30}$/;
    var ok = regexp.test(fra);
    if (!ok) {

        document.getElementById("feilFra").innerHTML = "Feil  reiseFra";
    
        return false;

    } else  {
        document.getElementById("feilFra").innerHTML = "";

        document.getElementById("til").style.display = "initial";

       
        return true;
    }

}

function validerFra(fra) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(fra);
    if (!ok) {
        $("#feilFra").html("Fra må bestå av 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#feilFra").html("");
        return true;
    }
}
function validerTil(til) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(til);
    if (!ok) {
        $("#feilTil").html("Til må bestå av 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#feilTil").html("");
        return true;
    }
}





function validerTurTil(til) {
    var regexp = /^[a-zA-ZÆØÅæøå]{2,30}$/;
    var ok = regexp.test(til);
    if (!ok) {
        $("#feilTil").html("Tur start  må velges");
        return false;
    } else {
        document.getElementById("feilTil").innerHTML = "";
        document.getElementById("datoType").style.display = "initial";

        return true;
    }
}



function validerDato(dato) {
  
        var regexp = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        var ok = regexp.test(dato);
        if (!ok) {
            $("#feilFraDato").html("dato er ikke gyldig");
            return false;
        } else {
            $("#feilFraDato").html("");
            return true;
        }
   
}


function hentAlleBilleter() {

    const billetArray = [];


    $.get("Home/HentalleStrekninger", function (strekninger) {
        for (let x in strekninger) {
            billetArray.push(x.Fra);

        }
    })
    return billetArray.Fra;
}

