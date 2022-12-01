rot2trans <- function(rot) {
  arr = 0:23;
  for (tp in rot) {
    indices = tp+1;
    for (ii in 1:length(indices)) {
      arr[indices[ii]] = tp[ii %% length(indices) + 1]; 
    }
  }
  arr;
}

#o2n <- 0:23
#rotF= list(c(3,14,20,5),c(2,12,21,7),c(8,9,11,10))
#trF = rot2trans(rotF);

transform <-function(vec,vals) {
  return(vec[vals+1]);
} 

transforms = list(
  
  list(name = "U", rot=list(c(21,17,9,5),
                            c(20,16,8,4),
                            c(0,2,3,1))),
  list(name = "R", rot=list(c(3,11,15,20),
                            c(1,9,13,22),
                            c(4,6,7,5))),
  list(name = "F", rot=list(c(2,19,13,4),
                            c(3,17,12,6),
                            c(8,10,11,9))),
  list(name = "D", rot=list(c(10,18,22,6),
                            c(11,19,23,7),
                            c(12,14,15,13))),
  list(name = "L", rot=list(c(0,23,12,8),
                            c(2,21,14,10),
                            c(16,18,19,17))),
  list(name = "B", rot=list(c(20,22,23,21),
                            c(0,5,15,18),
                            c(1,7,14,16)))
)

tble = data.frame();
for (trs in transforms) {
  tr=rot2trans(trs$rot);rots = lapply(1:nrow(tble), function(x) unlist(tble[x,]));
  names(rots) = row.names(tble);
  tr2=transform(tr,tr);
  trprime= transform(tr,transform(tr,transform(0:23,tr)));
  subtab=rbind(tr,trprime,tr2);
  row.names(subtab) = paste0(trs$name,c("","'","2"));
  tble=rbind(tble, subtab);
}

ss = "new int [][]{";
for (ii in 1:nrow(tble)) {
  ss=paste0(ss,ifelse(ii==1,"",",")," new int[]  {",paste(tble[ii,],collapse=","),"} //",row.names(tble)[ii],"\n");
}
ss = paste0(ss,"}")
writeLines(ss);

trf <- function(pos, trans) { 
  map = unlist(trans)+1; 
  map[pos+1]-1;  
}

rotate<-function(cube,cmd) {
  trans=unlist(tble[cmd,])+1
  cube[trans];
}

colordic=list(u="yellow",r="blue",f="orange",d="white",l="green",b="red" );


polygonWithLabel<-function(x,y,col="",label="") {
#  browser();
  polygon(x,y,col=col); #3
  cx=(min(x)+max(x))/2;
  cy=(min(y)+max(y))/2;
  text(cx,cy,label);
}

drawPartialCubeFront<-function(faces,centerx,centery,ch=2,cw=2,labels=c("","","")) {
  facecolor = sapply(faces, function(x) colordic[[x]])
  polyUp<-function(cx,cy) {
    list(x=c(cx,cx+cw,cx,cx-cw,cx),y=c(cy,cy+ch, cy+2*ch, cy + ch,cy));
  }
  polyFront<-function(cx,cy) {
    list(x=c(cx,cx-cw,cx-cw,cx,cx),y=c(cy,cy+ch, cy-ch, cy -2*ch,cy));
  }
  polyRight<-function(cx,cy) {
    list(x=c(cx,cx+cw,cx+cw,cx,cx),y=c(cy,cy+ch, cy-ch, cy -2*ch,cy));
  }
  pUP = polyUp(centerx,centery);
  pFront = polyFront(centerx,centery);
  pRight = polyRight(centerx,centery);
  polygonWithLabel(pUP$x, pUP$y,col=facecolor[4],label="3") #3
  polygonWithLabel(pUP$x+cw, pUP$y+ch,col=facecolor[2],label="1") #1
  polygonWithLabel(pUP$x, pUP$y+2*ch,col=facecolor[1],label="0") #0
  polygonWithLabel(pUP$x-cw, pUP$y+ch,col=facecolor[3],label="2") #2
  polygonWithLabel(pFront$x, pFront$y,col=facecolor[10],label="9") #9
  polygonWithLabel(pFront$x-cw, pFront$y+ch,col=facecolor[9],label="8") #8
  polygonWithLabel(pFront$x-cw, pFront$y-ch,col=facecolor[11],label="10") #10
  polygonWithLabel(pFront$x, pFront$y-2*ch,col=facecolor[12],label="11") #11
  polygonWithLabel(pRight$x, pRight$y,col=facecolor[5],label="4") #4
  polygonWithLabel(pRight$x, pRight$y-2*ch,col=facecolor[7],label="6") #6
  polygonWithLabel(pRight$x+cw, pRight$y-ch,col=facecolor[8],label="7") #7
  polygonWithLabel(pRight$x+cw, pRight$y+ch,col=facecolor[6],label="5") #5
  text(pUP$x[1],pUP$y[1]+2*ch,labels[1]);
  text(pUP$x[1]-ch,pUP$y[1]-ch,labels[3]);
  text(pUP$x[1]+ch,pUP$y[1]-ch,labels[2]);  
}

drawPartialCubeBack<-function(faces,centerx,centery,ch=2,cw=2,labels=c("","","")) {
  facecolor = sapply(faces, function(x) colordic[[x]])
  polyUp<-function(cx,cy) {
    list(x=c(cx,cx+cw,cx,cx-cw,cx),y=c(cy,cy-ch, cy-2*ch, cy - ch,cy));
  }
  polyFront<-function(cx,cy) {
    list(x=c(cx,cx-cw,cx-cw,cx,cx),y=c(cy,cy-ch, cy+ch, cy +2*ch,cy));
  }
  polyRight<-function(cx,cy) {
    list(x=c(cx,cx+cw,cx+cw,cx,cx),y=c(cy,cy-ch, cy+ch, cy +2*ch,cy));
  }
  pUP = polyUp(centerx,centery);
  pFront = polyFront(centerx,centery);
  pRight = polyRight(centerx,centery);
  polygonWithLabel(pUP$x, pUP$y,col=facecolor[3],label="14") #3              Down
  polygonWithLabel(pUP$x+cw, pUP$y-ch,col=facecolor[1],label="12") #1
  polygonWithLabel(pUP$x, pUP$y-2*ch,col=facecolor[2],label="13") #0
  polygonWithLabel(pUP$x-cw, pUP$y-ch,col=facecolor[4],label="15") #2
  polygonWithLabel(pFront$x, pFront$y,col=facecolor[12],label="23") #9             Back
  polygonWithLabel(pFront$x, pFront$y+2*ch,col=facecolor[10],label="21") #8
  polygonWithLabel(pFront$x-cw, pFront$y+ch,col=facecolor[9],label="20") #10
  polygonWithLabel(pFront$x-cw, pFront$y-ch,col=facecolor[11],label="22") #11
  polygonWithLabel(pRight$x, pRight$y,col=facecolor[7],label="18") #4              
  polygonWithLabel(pRight$x, pRight$y+2*ch,col=facecolor[5],label="16") #6
  polygonWithLabel(pRight$x+cw, pRight$y+ch,col=facecolor[6],label="17") #7
  polygonWithLabel(pRight$x+cw, pRight$y-ch,col=facecolor[8],label="19") #5
  text(pUP$x[1],pUP$y[1]-2*ch,labels[1]);
  text(pUP$x[1]+ch,pUP$y[1]+ch,labels[2]);
  text(pUP$x[1]-ch,pUP$y[1]+ch,labels[3]);    
}



drawCube <- function(cube, label="") {
  faces1= cube[1:12];
  faces2= cube[13:24];
  
  plot(c(-9,9),c(-8,8), type="n",ylab="", xaxt='n', yaxt='n',ann=FALSE);
  drawPartialCubeFront(faces1,-5,0,labels=c("Up","Right","Front"));
  drawPartialCubeBack(faces2, 5,0, labels=c("Down","Left","Back"));
  text(0,7,label)
}



polyCenter<-function(cx,cy,cw=2,ch=2) {
  list(x=c(cx,cx+cw,cx+cw,cx,cx),y=c(cy,cy, cy+ch, cy + ch,cy));
}
polyUp<-function(cx,cy,cw=2,ch=2) {
  list(x=c(cx,cx+cw,cx+0.75*cw, cx+0.25*cw,cx),y=c(cy,cy, cy+0.5*ch, cy+0.5*ch,cy));
}
polyRight<-function(cx,cy,cw=2,ch=2) {
  list(x=c(cx,cx+0.5*cw,cx+0.5*cw,cx,cx),y=c(cy,cy+0.25*ch, cy+0.75*ch, cy+ch,cy));
}

polyDown<-function(cx,cy,cw=2,ch=2) {
  list(x=c(cx,cx+0.25*cw,cx+0.75*cw, cx+cw,cx),y=c(cy+ch,cy+0.5*ch, cy+0.5*ch, cy+ch,cy+ch));
}

polyLeft<-function(cx,cy,cw=2,ch=2) {
  list(x=c(cx+cw,cx+0.5*cw,cx+0.5*cw,cx+cw,cx+cw),y=c(cy,cy+0.25*ch, cy+0.75*ch, cy+ch,cy));
}


drawPartialCubeUp<-function(faces,centerx,centery,ch=2,cw=2,labels=c("","","")) {
  facecolor = sapply(faces, function(x) colordic[[x]])
  
  pUp = polyUp(centerx,centery,cw=cw,ch=ch);
  pRight = polyRight(centerx,centery,cw=cw,ch=ch);
  pLeft = polyLeft(centerx,centery,cw=cw,ch=ch);
  pCenter = polyCenter(centerx,centery,cw=cw,ch=ch);
  pDown = polyDown(centerx,centery,cw=cw,ch=ch);
  
  polygonWithLabel(pCenter$x, pCenter$y,col=facecolor[3],label="2") #2
  polygonWithLabel(pCenter$x, pCenter$y+ch,col=facecolor[1],label="0") #0
  polygonWithLabel(pCenter$x+cw, pCenter$y,col=facecolor[4],label="3") #3
  polygonWithLabel(pCenter$x+cw, pCenter$y+ch,col=facecolor[2],label="1") #1
  
  polygonWithLabel(pLeft$x-ch, pLeft$y,col=facecolor[18],label="17") #17
  polygonWithLabel(pLeft$x-ch, pLeft$y+ch,col=facecolor[17],label="16") #16
  polygonWithLabel(pRight$x+2*cw, pRight$y,col=facecolor[5],label="4") #4
  polygonWithLabel(pRight$x+2*cw, pRight$y+ch,col=facecolor[6],label="5") #5
  
  polygonWithLabel(pUp$x, pUp$y+2*ch,col=facecolor[22],label="21") #21
  polygonWithLabel(pUp$x+cw, pUp$y+2*ch,col=facecolor[21],label="20") #20
  polygonWithLabel(pDown$x, pDown$y-ch,col=facecolor[9],label="8") #8
  polygonWithLabel(pDown$x+cw, pDown$y-ch,col=facecolor[10],label="9") #9
}

drawPartialCubeDown<-function(faces,centerx,centery,ch=2,cw=2,labels=c("","","")) {
  facecolor = sapply(faces, function(x) colordic[[x]])
  
  pUp = polyUp(centerx,centery,cw=cw,ch=ch);
  pRight = polyRight(centerx,centery,cw=cw,ch=ch);
  pLeft = polyLeft(centerx,centery,cw=cw,ch=ch);
  pCenter = polyCenter(centerx,centery,cw=cw,ch=ch);
  pDown = polyDown(centerx,centery,cw=cw,ch=ch);
  
  polygonWithLabel(pCenter$x, pCenter$y,col=facecolor[15],label="14") #14
  polygonWithLabel(pCenter$x, pCenter$y+ch,col=facecolor[13],label="12") #12
  polygonWithLabel(pCenter$x+cw, pCenter$y,col=facecolor[16],label="15") #15
  polygonWithLabel(pCenter$x+cw, pCenter$y+ch,col=facecolor[14],label="13") #13
  
  polygonWithLabel(pLeft$x-ch, pLeft$y,col=facecolor[19],label="18") #18
  polygonWithLabel(pLeft$x-ch, pLeft$y+ch,col=facecolor[20],label="19") #19
  polygonWithLabel(pRight$x+2*cw, pRight$y,col=facecolor[8],label="7") #7
  polygonWithLabel(pRight$x+2*cw, pRight$y+ch,col=facecolor[7],label="6") #6
  
  polygonWithLabel(pUp$x, pUp$y+2*ch,col=facecolor[11],label="10") #10
  polygonWithLabel(pUp$x+cw, pUp$y+2*ch,col=facecolor[12],label="11") #11
  polygonWithLabel(pDown$x, pDown$y-ch,col=facecolor[24],label="23") #23
  polygonWithLabel(pDown$x+cw, pDown$y-ch,col=facecolor[23],label="22") #22
}

drawCubeUpDown <- function(cube, label="") {
  
  plot(c(-7,7),c(-4,4), type="n",ylab="", xaxt='n', yaxt='n',ann=FALSE);
  drawPartialCubeUp(cube,-6,-2);
  drawPartialCubeDown(cube,2,-2);
  #drawPartialCubeBack(faces2, 5,0, labels=c("Down","Left","Back"));
  text(0,5,label)
}

