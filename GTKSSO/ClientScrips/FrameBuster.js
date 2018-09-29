function FrameBuster() {
    //if (self != top)
    //    window.open(self.document.location, "_top", "");
  
        if (self === top) {
       var antiClickjack = document.getElementById("antiClickjack");
       antiClickjack.parentNode.removeChild(antiClickjack);
   } else {
            top.location = self.location;
        }
}