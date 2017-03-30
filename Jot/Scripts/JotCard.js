
//CARD_HEIGHT -- Start
//below script is to ensure that iFrame pops up with proper height (of card height)
// Create IE + others compatible event handler
var eventMethod = window.addEventListener ? "addEventListener" : "attachEvent";
var eventer = window[eventMethod];
var messageEvent = eventMethod == "attachEvent" ? "onmessage" : "message";
console.log('eventMethod [' + eventMethod + '] <-> messageEvent [' + messageEvent + ']');

// Listen to message from child window
eventer(messageEvent, function (e) {
    console.log('parent received message!:  ', e.data);
    document.getElementById('jotCardFrame').height = e.data + 'px';
}, false);
//CARD_HEIGHT -- End

//iFRAME_LOAD -- start
var jotURLParams = '';
var jotURI = 'http://localhost:55650/home/card?';
//script to create the iFrame so that it does not get loaded along with the modal DIV. esentially this is delayed loading
function popJotCard() {
    document.getElementById('jotCardSpaceBody').innerHTML = "<iframe id=\"jotCardFrame\" src=\"" + jotURI + jotURLParams + "\"></iframe>";
}
//iFRAME_LOAD -- end

// Get the modal
var vModal = document.getElementById('jotModal');

// Get the button that opens the modal
var bBtn = document.getElementById("jotBtn");

// Get the <span> element that closes the modal
var vSpan = document.getElementsByClassName("jot-close")[0];

// When the user clicks on the button, open the modal 
if (bBtn) {
    bBtn.onclick = function () {
        vModal.style.display = "block";
        popJotCard();
    }
}

// When the user clicks on <span> (x), close the modal
if (vSpan) {
    vSpan.onclick = function () {
        vModal.style.display = "none";
    }
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == vModal) {
        vModal.style.display = "none";
    }
}