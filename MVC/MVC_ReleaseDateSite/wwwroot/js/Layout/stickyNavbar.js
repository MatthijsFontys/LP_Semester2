window.onscroll = function() {checkForFixedNav()};

let nav = document.getElementById("mainNav");

let navOffset = nav.offsetTop;

function checkForFixedNav() {
  if (window.pageYOffset > navOffset)
    nav.classList.add("sticky");
  else
    nav.classList.remove("sticky");
}