function nav(f){
  var theUrl = f.jump.options[f.jump.selectedIndex].value ;
  if (theUrl != ""){
      location.href = theUrl ;
  }
}