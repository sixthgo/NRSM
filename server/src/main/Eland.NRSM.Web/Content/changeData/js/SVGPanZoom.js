var selectedRec;
var viewBox;
var boundaryx;
var boundaryy;
var boundarywidth;
var boundaryheight;

var svgs;
var svgCanvas;
var mainCanvas;

var minX;
var minY;
var maxX;
var maxY;

var gViewport;
var mouseState;

var Modes = { "none": 0, "prepanning": 1, "panning": 2, "scale": 3, "preregionzoom":4, "regionzoom": 5 };
var state = Modes.none;

var selection;
var selectionStroke;
var selectionStrokeWidth;
var firstHeight;
var isFirst = true;
var layoutHeight;

$(document).ready(function () {

    var localHeight = $(window).height(); //localStorage.getItem('mobileHeight');
    var localWidth = $(window).width(); //localStorage.getItem('mobileWidth');

    var dpHeight = localHeight - 25; // 75

    var styleHeight = dpHeight + "px";

    document.getElementById("mainCanvas").style.height = styleHeight;
    document.getElementById("mainCanvas").style.width = "100%";
    
    var svgs = document.getElementsByTagName("svg");
    svgs[0].style.height = styleHeight;
    
	window.addEventListener('load', function(){
		setTimeout(scrollTo, 0, 0, 1);
	}, false);

    $("#mainbody").ready(function () {

	    InitializeElements();
        FitZoom();

        mouseState.Attach(document.getElementById("mainCanvas"));

        var sheet = document.createElement('style')
        sheet.innerHTML = "p {font-family:굴림; font-size:11px}";
        document.body.appendChild(sheet);

        var sheet1 = document.createElement('style')
        sheet1.innerHTML = "a {font-family:굴림; font-size:13px}";
        document.body.appendChild(sheet1);
    });

    $(window).resize(function () {
        gViewport.SetScreen(mainCanvas.clientWidth, mainCanvas.clientHeight);
        //FitZoom();
    });
});

function InitializeElements() {
    svgs = document.getElementsByTagName("svg");
    svgCanvas = svgs[0].childNodes[3];

    boundarywidth = Number(svgs[0].getAttribute("gy:width"));
    boundaryheight = Number(svgs[0].getAttribute("gy:height"));

    minX = Number(svgs[0].getAttribute("gy:x"));
    minY = Number(svgs[0].getAttribute("gy:y"));
    maxX = minX + boundarywidth;
    maxY = minY + boundaryheight;

    mouseState = new MouseState();
    gViewport = new Viewport(boundaryheight, { X: minX + boundarywidth / 2, Y: minY + boundaryheight / 2 });

    mainCanvas = document.getElementById("mainCanvas");
    gViewport.SetScreen(mainCanvas.clientWidth, mainCanvas.clientHeight);
};

function FitZoom() {
	CheckToggle();
    gViewport.RegionZoom({ X: minX, Y: minY }, { X: maxX, Y: maxY });
    gViewport.Apply(svgCanvas);
}

function CheckToggle(){
	if (state == Modes.preregionzoom || state == Modes.regionzoom){
		$("#imgRegionZoom")[0].src = "icons/RegionZoom.png";
		state = Modes.none;
	}
}

function Viewport(height, lookat) {
    this.Height = height;
    this.LookAt = lookat;
    this.ScreenWidth = 100;
    this.ScreenHeight = 100;

    this.Scale = 1;
    this.Translate = { X: 0, Y: 0 };

    this.SetScreen = function (screenWidth, screenHeight) {
        this.ScreenWidth = screenWidth;
        this.ScreenHeight = screenHeight;
        this.Update();
    };

    this.Update = function () {
        this.Scale = this.ScreenHeight / this.Height;

    };
    this.Zoom = function (height) {
        this.Height += height;
        this.Height = Math.max(this.Height, 10);
        this.Update();
    };

    this.BeginPan = function () {
        
        this.IsHiddenElement = true;
    };

    this.Pan = function (x, y) {
        
        this.LookAt.X += x;
        this.LookAt.Y += y;
        this.Update();
    };

    this.EndPan = function () {
        
    };

    this.RegionZoom = function (minv, maxv) {
        var lookAt = { X: (minv.X + maxv.X) / 2, Y: (minv.Y + maxv.Y) / 2 };
        var h = Math.abs(maxv.Y - minv.Y);
        var w = Math.abs(maxv.X - minv.X);

        var srat = this.ScreenHeight / this.ScreenWidth;
        var wrat = h / w;

        if (srat > wrat)
            h = srat * w;

        this.Height = h;
        this.LookAt = lookAt;

        this.Update();
    };

    this.Apply = function (canvas) {
        canvas.setAttribute("transform",
        										"translate(" + this.ScreenWidth / 2 + " " + this.ScreenHeight / 2 + ")" + " scale(" + this.Scale + ")" + "translate(" + -this.LookAt.X + " " + -this.LookAt.Y + ")");
    };
}
function MouseState() {
    this.oldX = 0;
    this.oldY = 0;
    this.scrposX = 0;
    this.scrposY = 0;
    this.basedistance = 1;
    
    this.basePointX = 0;
    this.basePointY = 0;
    this.Hide = false;
    this.isMultiTouch = false;
    this.oldScrollposX = 0;
    this.oldScrollposY = 0;

    this.AttachTo = 0;

    this.Movebegin = function (e) {
        if (e.touches != null) {
             if (state == Modes.preregionzoom) {            	
				state = Modes.regionzoom;
				this.isMultiTouch = false;
				var mat = svgCanvas.getCTM();
                this.regionstart = ScreenToWorld(mat, { X: e.touches[0].pageX - 9, Y: e.touches[0].pageY - 9 });
                CreateRegionBox(this.regionstart, this.regionend);
            }
            else if (e.touches.length == 1) {
                var posx = e.touches[0].pageX; //e.pageX;
                var posy = e.touches[0].pageY; //e.pageY;
                this.isMultiTouch = false;
				state = Modes.prepanning;
                this.oldX = posx;
                this.oldY = posy;
                gViewport.BeginPan();
            }         
            else if(state != Modes.preregionzoom 
            				&& state != Modes.regionzoom
            				&& e.touches.length ==2){   
                state = Modes.scale;
                this.isMultiTouch = true;
                this.basePointX = e.touches[0].pageX;
                this.basePointY = e.touches[0].pageY;
                // this.basePointX = (e.touches[0].pageX+ e.touches[1].pageX)/2;
                //  this.basePointY = (e.touches[0].pageY+ e.touches[1].pageY)/2;
                this.oldX = e.touches[1].pageX;
                this.oldY = e.touches[1].pageY;
                var mat = svgCanvas.getCTM();
                var temppos = { X: this.oldX, Y: this.oldY };
                var basepoint = { X: this.basePointX, Y: this.basePointY };
                this.oldWorldPos = ScreenToWorld(mat, temppos);  // 두번째 손가락의 월드위치 받음
                var baseWorldPos = ScreenToWorld(mat, basepoint);  // 첫번째 손가락의 월드위치 받음
                this.oldWorldDistance = GetDistance(baseWorldPos.X, baseWorldPos.Y, this.oldWorldPos.X, this.oldWorldPos.Y); // 손가락의 월드거리
                this.oldScreenDistance = GetDistance(this.basePointX, this.basePointY, this.oldX, this.oldY); // 손가락의 스크린거리
                gViewport.BeginPan();
                if (gViewport.IsHiddenElement) {
                    gViewport.HiddenChild.setAttribute('visibility', 'hidden');
                }
            }
        }
        else {
            if (state == Modes.none) {
                var posx = e.pageX;
                var posy = e.pageY;
                state = Modes.prepanning;
                this.oldX = posx;
                this.oldY = posy;
                gViewport.BeginPan();
            }
            else if (state == Modes.preregionzoom) {                
                state = Modes.regionzoom;

                var mat = svgCanvas.getCTM();
                this.regionstart = ScreenToWorld(mat, { X: e.pageX - 9, Y: e.pageY - 9 });
                CreateRegionBox(this.regionstart, this.regionend);
            }
        }
        e.preventDefault();
    };
    this.Move = function (e) {
        if (e.touches != null) {
            if (state == Modes.prepanning || state == Modes.panning) {
                state = Modes.panning;
                var posx = e.touches[0].pageX; //e.pageX;
                var posy = e.touches[0].pageY; //e.pageY;
                gViewport.Pan((this.oldX - posx) / gViewport.Scale, (this.oldY - posy) / gViewport.Scale);
                gViewport.Apply(svgCanvas);
                this.oldX = posx;
                this.oldY = posy;
            }
            else if (state == Modes.scale) {

                var movedfinger = 3; // 3=default, 1 = base, 2 = movedfinger, 4 = both	 
                var posx = e.touches[1].pageX; //e.pageX;
                var posy = e.touches[1].pageY; //e.pageY;

                if (Math.abs(posx - this.oldX) > 1 || Math.abs(posy - this.oldY) > 1) {
                    movedfinger = 2;

                }
                if (Math.abs(this.basePointX - e.touches[0].pageX) > 1 || Math.abs(this.basePointY - e.touches[0].pageY) > 1) {
                    if (movedfinger == 2)
                        movedfinger = 4;
                    else
                        movedfinger = 1;
                }
                this.basePointX = e.touches[0].pageX;
                this.basePointY = e.touches[0].pageY;
                this.oldX = posx;
                this.oldY = posy;
                if (movedfinger == 2) {
                    var newScreenpos = { X: posx, Y: posy };
                    var baseScreenPos = { X: this.basePointX, Y: this.basePointY };
                }
                else if (movedfinger == 1) {
                    var baseScreenPos = { X: posx, Y: posy };
                    var newScreenpos = { X: this.basePointX, Y: this.basePointY };
                }
                else if (movedfinger == 4) {
                    var baseScreenPos = { X: (posx + this.basePointX) / 2, Y: (posy + this.basePointY) / 2 };
                    var newScreenpos = { X: this.basePointX, Y: this.basePointY };
                }


                var beforematrix = svgCanvas.getCTM();  //이동전 의 매트릭스 받아옴

                //   var newWorldpos = ScreenToWorld(beforematrix, newScreenpos); //현재손가락의월드위치
                var beforebaseWorldPos = ScreenToWorld(beforematrix, baseScreenPos); //현재베이스의월드위치
                var currentScreenDistance = GetDistance(baseScreenPos.X, baseScreenPos.Y, newScreenpos.X, newScreenpos.Y); //베이스와 손가락의 스크린거리
                //  var currentWorldDistance = GetDistance(beforebaseWorldPos.X, beforebaseWorldPos.Y, newWorldpos.X, newWorldpos.Y); //베이스와 손가락의 스크린거리
                if (movedfinger == 4)
                    currentScreenDistance = currentScreenDistance * 2;
                var rate = currentScreenDistance / this.oldScreenDistance;
                this.oldScreenDistance = currentScreenDistance;
                if (rate > 1.5) {
                    rate = 1.5;
                }
                gViewport.Zoom(gViewport.Height - (gViewport.Height * rate));
                // gViewport.Apply(svgCanvas);

                //var tempmatrix = svgCanvas.getCTM();

                var TransMat = new GMatrix();
                var ScaleMat = new GMatrix();
                var TransMat2 = new GMatrix();
                TransMat.M41 = -gViewport.LookAt.X;
                TransMat.M42 = -gViewport.LookAt.Y;
                ScaleMat.M11 = gViewport.Scale;
                ScaleMat.M22 = gViewport.Scale;
                TransMat2.M41 = gViewport.ScreenWidth / 2;
                TransMat2.M42 = gViewport.ScreenHeight / 2;
                var aftertrans = Multifly(Multifly(TransMat, ScaleMat), TransMat2);  // Scale 이 먼저 되었을때의 매트릭스값구함.

                var aftermatrix = svgCanvas.getCTM();

                aftermatrix.a = aftertrans.M11;
                aftermatrix.d = aftertrans.M11;
                aftermatrix.e = aftertrans.M41;
                aftermatrix.f = aftertrans.M42;

                var afterbaseWorldpos = ScreenToWorld(aftermatrix, baseScreenPos);
                //  var afterpos = ScreenToWorld(aftermatrix, newScreenpos);

                gViewport.LookAt.X += (beforebaseWorldPos.X - afterbaseWorldpos.X);
                gViewport.LookAt.Y += (beforebaseWorldPos.Y - afterbaseWorldpos.Y);


                gViewport.Apply(svgCanvas);

            }
            else if (state == Modes.regionzoom) {
                var mat = svgCanvas.getCTM();
                this.regionend = ScreenToWorld(mat, { X: e.touches[0].pageX - 9, Y: e.touches[0].pageY - 9 });

                if (document.querySelector('#regionBox') != null) {
                    if (this.regionend.X > this.regionstart.X) {
                        document.querySelector('#regionBox').setAttribute("width", this.regionend.X - this.regionstart.X);
                        document.querySelector('#regionBox').setAttribute("x", this.regionstart.X);
                    }
                    else {
                        document.querySelector('#regionBox').setAttribute("width", Math.abs(this.regionend.X - this.regionstart.X));
                        document.querySelector('#regionBox').setAttribute("x", this.regionend.X);
                    }

                    if (this.regionend.Y > this.regionstart.Y) {
                        document.querySelector('#regionBox').setAttribute("height", this.regionend.Y - this.regionstart.Y);
                        document.querySelector('#regionBox').setAttribute("y", this.regionstart.Y);
                    }
                    else {
                        document.querySelector('#regionBox').setAttribute("height", Math.abs(this.regionend.Y - this.regionstart.Y));
                        document.querySelector('#regionBox').setAttribute("y", this.regionend.Y);
                    }
                }
            }
            else if (state == Modes.none) {
                if (this.isMultiTouch == true) {
                    //	 var scposX = e.touches[0].pageX;
                    //		 var scposY = e.touches[0].pageY;
                    //		 document.body.scrollLeft += scposX - this.oldScrollposX;
                    //	 document.body.scrollTop += scposY - this.oldScrollposY;
                    //	 this.oldScrollposX =scposX;
                    //  this.oldScrollposY =scposY;
                }
            }

        } 
		else {
            if (state == Modes.prepanning || state == Modes.panning) {
                state = Modes.panning;
                var posx = e.pageX;
                var posy = e.pageY;
                gViewport.Pan((this.oldX - posx) / gViewport.Scale, (this.oldY - posy) / gViewport.Scale);
                gViewport.Apply(svgCanvas);
                this.oldX = posx;
                this.oldY = posy;
            }
            else if (state == Modes.regionzoom) {
                var mat = svgCanvas.getCTM();
                this.regionend = ScreenToWorld(mat, { X: e.pageX - 9, Y: e.pageY - 9 });

                if (document.querySelector('#regionBox') != null) {
                    if (this.regionend.X > this.regionstart.X) {
                        document.querySelector('#regionBox').setAttribute("width", this.regionend.X - this.regionstart.X);
                        document.querySelector('#regionBox').setAttribute("x", this.regionstart.X);
                    }
                    else {
                        document.querySelector('#regionBox').setAttribute("width", Math.abs(this.regionend.X - this.regionstart.X));
                        document.querySelector('#regionBox').setAttribute("x", this.regionend.X);
                    }

                    if (this.regionend.Y > this.regionstart.Y) {
                        document.querySelector('#regionBox').setAttribute("height", this.regionend.Y - this.regionstart.Y);
                        document.querySelector('#regionBox').setAttribute("y", this.regionstart.Y);
                    }
                    else {
                        document.querySelector('#regionBox').setAttribute("height", Math.abs(this.regionend.Y - this.regionstart.Y));
                        document.querySelector('#regionBox').setAttribute("y", this.regionend.Y);
                    }
                }
            }
        }
        e.preventDefault();
    };

    this.Moveend = function (e) {
        if (state == Modes.panning) {
            gViewport.EndPan();
            state = Modes.none;
        }
        else if (state == Modes.scale) {
            gViewport.EndPan();
            state = Modes.none;
            this.oldScrollposX = e.touches[0].pageX;
            this.oldScrollposY = e.touches[0].pageY;
        }
         else if (state == Modes.regionzoom) {
            RemoveRegionBox();

            gViewport.RegionZoom(this.regionstart, this.regionend);
            gViewport.Apply(svgCanvas);
			$("#imgRegionZoom")[0].src = "icons/RegionZoom.png";
            state = Modes.none;
        }
        else {
            if (this.isMultiTouch != true) {
                
                state = Modes.none;
            }
        }
        e.preventDefault();
    };

    this.MouseWheel = function (e) {
        alert("as");
        gViewport.ZoomIn(gViewport.Height * 0.1 * e.delt);
        gViewport.Apply(svgCanvas);
    };
	
    this.Attach = function (target) {
        this.AttachTo = target;
        target.addEventListener("mousedown", this.Movebegin, false);
        target.addEventListener("mousemove", this.Move, false);
        target.addEventListener("mouseup", this.Moveend, false);

        target.addEventListener("touchstart", this.Movebegin, false);
        target.addEventListener("touchmove", this.Move, false);
        target.addEventListener("touchend", this.Moveend, false);
    };
}

function GMatrix() {
    this.M11 = 1;
    this.M12 = 0;
    this.M13 = 0;
    this.M14 = 0;
    this.M21 = 0;
    this.M22 = 1;
    this.M23 = 0;
    this.M24 = 0;
    this.M31 = 0;
    this.M32 = 0;
    this.M33 = 1;
    this.M34 = 0;
    this.M41 = 0;
    this.M42 = 0;
    this.M43 = 0;
    this.M44 = 1;
}

function Invert(matrix) {
    var matrix2 = new GMatrix();
    var num5 = matrix.M11;
    var num4 = matrix.M12;
    var num3 = matrix.M13;
    var num2 = matrix.M14;
    var num9 = matrix.M21;
    var num8 = matrix.M22;
    var num7 = matrix.M23;
    var num6 = matrix.M24;
    var num17 = matrix.M31;
    var num16 = matrix.M32;
    var num15 = matrix.M33;
    var num14 = matrix.M34;
    var num13 = matrix.M41;
    var num12 = matrix.M42;
    var num11 = matrix.M43;
    var num10 = matrix.M44;
    var num23 = (num15 * num10) - (num14 * num11);
    var num22 = (num16 * num10) - (num14 * num12);
    var num21 = (num16 * num11) - (num15 * num12);
    var num20 = (num17 * num10) - (num14 * num13);
    var num19 = (num17 * num11) - (num15 * num13);
    var num18 = (num17 * num12) - (num16 * num13);
    var num39 = ((num8 * num23) - (num7 * num22)) + (num6 * num21);
    var num38 = -(((num9 * num23) - (num7 * num20)) + (num6 * num19));
    var num37 = ((num9 * num22) - (num8 * num20)) + (num6 * num18);
    var num36 = -(((num9 * num21) - (num8 * num19)) + (num7 * num18));
    var num = 1 / ((((num5 * num39) + (num4 * num38)) + (num3 * num37)) + (num2 * num36));
    matrix2.M11 = num39 * num;
    matrix2.M21 = num38 * num;
    matrix2.M31 = num37 * num;
    matrix2.M41 = num36 * num;
    matrix2.M12 = -(((num4 * num23) - (num3 * num22)) + (num2 * num21)) * num;
    matrix2.M22 = (((num5 * num23) - (num3 * num20)) + (num2 * num19)) * num;
    matrix2.M32 = -(((num5 * num22) - (num4 * num20)) + (num2 * num18)) * num;
    matrix2.M42 = (((num5 * num21) - (num4 * num19)) + (num3 * num18)) * num;
    var num35 = (num7 * num10) - (num6 * num11);
    var num34 = (num8 * num10) - (num6 * num12);
    var num33 = (num8 * num11) - (num7 * num12);
    var num32 = (num9 * num10) - (num6 * num13);
    var num31 = (num9 * num11) - (num7 * num13);
    var num30 = (num9 * num12) - (num8 * num13);
    matrix2.M13 = (((num4 * num35) - (num3 * num34)) + (num2 * num33)) * num;
    matrix2.M23 = -(((num5 * num35) - (num3 * num32)) + (num2 * num31)) * num;
    matrix2.M33 = (((num5 * num34) - (num4 * num32)) + (num2 * num30)) * num;
    matrix2.M43 = -(((num5 * num33) - (num4 * num31)) + (num3 * num30)) * num;
    var num29 = (num7 * num14) - (num6 * num15);
    var num28 = (num8 * num14) - (num6 * num16);
    var num27 = (num8 * num15) - (num7 * num16);
    var num26 = (num9 * num14) - (num6 * num17);
    var num25 = (num9 * num15) - (num7 * num17);
    var num24 = (num9 * num16) - (num8 * num17);
    matrix2.M14 = -(((num4 * num29) - (num3 * num28)) + (num2 * num27)) * num;
    matrix2.M24 = (((num5 * num29) - (num3 * num26)) + (num2 * num25)) * num;
    matrix2.M34 = -(((num5 * num28) - (num4 * num26)) + (num2 * num24)) * num;
    matrix2.M44 = (((num5 * num27) - (num4 * num25)) + (num3 * num24)) * num;
    return matrix2;
};
function Multifly(matrix1, matrix2) {
    var matrix = new GMatrix();
    matrix.M11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
    matrix.M12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
    matrix.M13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
    matrix.M14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
    matrix.M21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
    matrix.M22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
    matrix.M23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
    matrix.M24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
    matrix.M31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
    matrix.M32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
    matrix.M33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
    matrix.M34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
    matrix.M41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
    matrix.M42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
    matrix.M43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
    matrix.M44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
    return matrix;
}

function ScreenToWorld(SVGMatrix, scnPos) {

    var mat = new GMatrix();
    mat.M11 = SVGMatrix.a;
    mat.M12 = 0;
    mat.M13 = 0;
    mat.M14 = 0;
    mat.M21 = 0;
    mat.M22 = SVGMatrix.d;
    mat.M23 = 0;
    mat.M24 = 0;
    mat.M31 = 0;
    mat.M32 = 0;
    mat.M33 = 1;
    mat.M34 = 0;
    mat.M41 = SVGMatrix.e;
    mat.M42 = SVGMatrix.f;
    mat.M43 = 0;
    mat.M44 = 1;
    var convertedmatrix = Invert(mat);
    var wpX = (((scnPos.X * convertedmatrix.M11) + (scnPos.Y * convertedmatrix.M21)) + (0 * convertedmatrix.M31)) + convertedmatrix.M41;
    var wpY = (((scnPos.X * convertedmatrix.M12) + (scnPos.Y * convertedmatrix.M22)) + (0 * convertedmatrix.M32)) + convertedmatrix.M42;
    return { X: wpX, Y: wpY };
}
function ConvertToGMatrix(SVGMatrix) {
    var result = new GMatrix();
    result.M11 = SVGMatrix.a;
    result.M12 = 0;
    result.M13 = 0;
    result.M14 = 0;
    result.M21 = 0;
    result.M22 = SVGMatrix.d;
    result.M23 = 0;
    result.M24 = 0;
    result.M31 = 0;
    result.M32 = 0;
    result.M33 = 1;
    result.M34 = 0;
    result.M41 = SVGMatrix.e;
    result.M42 = SVGMatrix.f;
    result.M43 = 0;
    result.M44 = 1;
    return result;
}
function GetDistance(oldX, oldY, curX, curY) {
    return Math.sqrt((Math.pow((curX - oldX), 2)) + (Math.pow((curY - oldY), 2)));
}