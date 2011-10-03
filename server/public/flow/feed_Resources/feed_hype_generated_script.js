//	HYPE.documents["feed"]

(function HYPE_DocumentLoader() {
	var resourcesFolderName = "feed_Resources";
	var documentName = "feed";
	var documentLoaderFilename = "feed_hype_generated_script.js";

	// find the URL for this script's absolute path and set as the resourceFolderName
	try {
		var scripts = document.getElementsByTagName('script');
		for(var i = 0; i < scripts.length; i++) {
			var scriptSrc = scripts[i].src;
			if(scriptSrc != null && scriptSrc.indexOf(documentLoaderFilename) != -1) {
				resourcesFolderName = scriptSrc.substr(0, scriptSrc.lastIndexOf("/"));
				break;
			}
		}
	} catch(err) {	}

	// load HYPE.js if it hasn't been loaded yet
	if(typeof HYPE == "undefined") {
		if(typeof window.HYPE_DocumentsToLoad == "undefined") {
			window.HYPE_DocumentsToLoad = new Array();
			window.HYPE_DocumentsToLoad.push(HYPE_DocumentLoader);

			var headElement = document.getElementsByTagName('head')[0];
			var scriptElement = document.createElement('script');
			scriptElement.type= 'text/javascript';
			scriptElement.src = resourcesFolderName + '/' + 'HYPE.js';
			headElement.appendChild(scriptElement);
		} else {
			window.HYPE_DocumentsToLoad.push(HYPE_DocumentLoader);
		}
		return;
	}
	
	var attributeTransformerMapping = {"BorderColorRight":"ColorValueTransformer","BackgroundColor":"ColorValueTransformer","BorderWidthBottom":"PixelValueTransformer","WordSpacing":"PixelValueTransformer","BoxShadowXOffset":"PixelValueTransformer","Opacity":"FractionalValueTransformer","BorderWidthRight":"PixelValueTransformer","BorderWidthTop":"PixelValueTransformer","BoxShadowColor":"ColorValueTransformer","BorderColorBottom":"ColorValueTransformer","FontSize":"PixelValueTransformer","BorderRadiusTopRight":"PixelValueTransformer","TextColor":"ColorValueTransformer","Rotate":"DegreeValueTransformer","Height":"PixelValueTransformer","PaddingLeft":"PixelValueTransformer","BorderColorTop":"ColorValueTransformer","Top":"PixelValueTransformer","BackgroundGradientStartColor":"ColorValueTransformer","TextShadowXOffset":"PixelValueTransformer","PaddingTop":"PixelValueTransformer","BackgroundGradientAngle":"DegreeValueTransformer","PaddingBottom":"PixelValueTransformer","PaddingRight":"PixelValueTransformer","Width":"PixelValueTransformer","TextShadowColor":"ColorValueTransformer","BorderColorLeft":"ColorValueTransformer","ReflectionOffset":"PixelValueTransformer","Left":"PixelValueTransformer","BorderRadiusBottomRight":"PixelValueTransformer","LineHeight":"PixelValueTransformer","BoxShadowYOffset":"PixelValueTransformer","ReflectionDepth":"FractionalValueTransformer","BorderRadiusTopLeft":"PixelValueTransformer","BorderRadiusBottomLeft":"PixelValueTransformer","TextShadowBlurRadius":"PixelValueTransformer","TextShadowYOffset":"PixelValueTransformer","BorderWidthLeft":"PixelValueTransformer","BackgroundGradientEndColor":"ColorValueTransformer","BoxShadowBlurRadius":"PixelValueTransformer","LetterSpacing":"PixelValueTransformer"};

var scenes = [{"timelines":{"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A_hover":{"framesPerSecond":30,"animations":[{"startValue":"#D8D8D8","isRelative":true,"endValue":"#D86065","identifier":"BackgroundGradientEndColor","duration":1,"timingFunction":"easeinout","type":0,"oid":"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A","startTime":0}],"identifier":"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A_hover","name":"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A_hover","duration":1},"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A_pressed":{"framesPerSecond":30,"animations":[{"startValue":"#D8D8D8","isRelative":true,"endValue":"#585858","identifier":"BackgroundGradientEndColor","duration":1,"timingFunction":"easeinout","type":0,"oid":"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A","startTime":0}],"identifier":"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A_pressed","name":"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A_pressed","duration":1},"kTimelineDefaultIdentifier":{"framesPerSecond":30,"animations":[],"identifier":"kTimelineDefaultIdentifier","name":"Main Timeline","duration":0}},"id":"7227469E-2E22-4E45-AFE1-44D9F9C47A23-85852-0000FEEE35D9D7C2","sceneIndex":0,"perspective":"600px","oid":"7227469E-2E22-4E45-AFE1-44D9F9C47A23-85852-0000FEEE35D9D7C2","initialValues":{"787C42C1-4903-457B-8D48-FB55E14B9ECB-85852-0000FF3C5FEA174D":{"PaddingTop":"8px","Position":"absolute","TagName":"div","PaddingRight":"8px","Display":"inline","Left":"117px","Height":"9px","Overflow":"visible","Width":"163px","ZIndex":"4","FontSize":"16px","TextColor":"#0000FF","WordWrap":"break-word","WhiteSpaceCollapsing":"preserve","PaddingBottom":"8px","PaddingLeft":"8px","Top":"181px","InnerHTML":"beat their score!"},"CB6AA929-AA1A-405D-AE51-58329369D2A2-85852-0000FF36A15C05FB":{"PaddingTop":"8px","Position":"absolute","TagName":"div","PaddingRight":"8px","Display":"inline","Left":"117px","Height":"33px","Overflow":"visible","Width":"163px","ZIndex":"3","FontSize":"16px","TextColor":"#000000","WordWrap":"break-word","WhiteSpaceCollapsing":"preserve","PaddingBottom":"8px","PaddingLeft":"8px","Top":"142px","InnerHTML":"Aaron just played Marbles!"},"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A":{"ActionOnMouseClick":{"type":1,"sceneOid":"727844AB-22BB-4CB7-896D-4E3614E3C31E-85852-0000FF8D763A99CE","transition":2},"BorderStyleTop":"Solid","BackgroundColor":"#F0F0F0","WordWrap":"break-word","Display":"inline","BoxShadowXOffset":"0px","BorderStyleRight":"Solid","BorderWidthBottom":"1px","BorderWidthRight":"1px","BorderWidthTop":"1px","BoxShadowColor":"#808080","ButtonHover":"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A_hover","BorderStyleLeft":"Solid","BorderColorBottom":"#A0A0A0","FontSize":"13px","BorderRadiusTopRight":"6px","TextColor":"#000000","InnerHTML":"Button","Height":"15px","TextAlign":"center","ZIndex":"11","PaddingLeft":"6px","Top":"352px","BackgroundGradientStartColor":"#FFFFFF","UserSelect":"none","WhiteSpaceCollapsing":"preserve","BorderColorTop":"#A0A0A0","PaddingTop":"6px","TagName":"div","BorderStyleBottom":"Solid","BackgroundGradientAngle":"0deg","PaddingBottom":"6px","Position":"absolute","PaddingRight":"6px","Width":"90px","BorderColorLeft":"#A0A0A0","BorderRadiusBottomRight":"6px","Left":"123px","BorderColorRight":"#A0A0A0","BoxShadowYOffset":"0px","BorderRadiusBottomLeft":"6px","ButtonPress":"9BA4C98D-578E-431F-B8C6-DACE868094E7-85852-0000FF6974E2963A_pressed","BorderRadiusTopLeft":"6px","BorderWidthLeft":"1px","Overflow":"visible","Cursor":"pointer","BackgroundGradientEndColor":"#D8D8D8","BoxShadowBlurRadius":"3px"},"90C3A426-231A-4926-8BB8-C3DBA331A136-85852-0000FF6215DC9B75":{"Position":"absolute","BackgroundOrigin":"content-box","Display":"inline","Left":"42px","BackgroundImage":"Dog.tif","Cursor":"pointer","Height":"48px","BackgroundSize":"100% 100%","ZIndex":"9","Overflow":"visible","Width":"48px","ActionOnMouseClick":{"type":5,"goToURL":"home.html","openInNewWindow":false},"Top":"244px","TagName":"div"},"A8E38643-4C19-4589-9054-214321102C9F-85852-0000FF47EC5AB80E":{"PaddingTop":"8px","Position":"absolute","TagName":"div","PaddingRight":"8px","Display":"inline","Left":"117px","Height":"33px","Overflow":"visible","Width":"163px","ZIndex":"7","FontSize":"16px","TextColor":"#000000","WordWrap":"break-word","WhiteSpaceCollapsing":"preserve","PaddingBottom":"8px","PaddingLeft":"8px","Top":"240px","InnerHTML":"Sonya just played GoFish!"},"1EC80458-41EA-498A-A1B6-4033A686D865-85852-0000FF47EBA69453":{"PaddingTop":"8px","Position":"absolute","TagName":"div","PaddingRight":"8px","Display":"inline","Left":"117px","Height":"9px","Overflow":"visible","Width":"163px","ZIndex":"6","FontSize":"16px","TextColor":"#0000FF","WordWrap":"break-word","WhiteSpaceCollapsing":"preserve","PaddingBottom":"8px","PaddingLeft":"8px","Top":"279px","InnerHTML":"beat their score!"},"3A0C6B69-6E01-412D-89C2-EF0DFBE1CD02-85852-0000FF6461A0978D":{"Position":"absolute","BackgroundOrigin":"content-box","Display":"inline","Left":"42px","BackgroundImage":"Cat.tif","Cursor":"pointer","Height":"48px","BackgroundSize":"100% 100%","ZIndex":"10","Overflow":"visible","Width":"48px","ActionOnMouseClick":{"type":5,"goToURL":"home.html","openInNewWindow":false},"Top":"146px","TagName":"div"}},"name":"feed","backgroundColor":"#FFFFFF"},{"timelines":{"kTimelineDefaultIdentifier":{"framesPerSecond":30,"animations":[],"identifier":"kTimelineDefaultIdentifier","name":"Main Timeline","duration":0}},"id":"727844AB-22BB-4CB7-896D-4E3614E3C31E-85852-0000FF8D763A99CE","sceneIndex":1,"perspective":"600px","oid":"727844AB-22BB-4CB7-896D-4E3614E3C31E-85852-0000FF8D763A99CE","initialValues":{"CBCCD4A9-FAD3-4480-A367-A935D65A511C-85852-0000FF981AB1066C":{"PaddingTop":"8px","Position":"absolute","TagName":"div","PaddingRight":"8px","Display":"inline","Left":"94px","Overflow":"visible","ZIndex":"2","FontSize":"16px","TextColor":"#000000","WordWrap":"break-word","WhiteSpaceCollapsing":"preserve","PaddingBottom":"8px","PaddingLeft":"8px","Top":"42px","InnerHTML":"Aarons page"},"F1294A3A-6E78-4CCD-8739-F55C31F62391-85852-0000FF971B12066C":{"Position":"absolute","BackgroundOrigin":"content-box","Left":"25px","Display":"inline","BackgroundImage":"Cat.tif","Height":"48px","Overflow":"visible","BackgroundSize":"100% 100%","ZIndex":"1","Top":"42px","Width":"48px","TagName":"div"}},"name":"home","backgroundColor":"#FFFFFF"}];

var javascriptMapping = {};


	
	var Custom = (function() {
	return {
	};
}());

	
	var hypeDoc = new HYPE();
	
	hypeDoc.attributeTransformerMapping = attributeTransformerMapping;
	hypeDoc.scenes = scenes;
	hypeDoc.javascriptMapping = javascriptMapping;
	hypeDoc.Custom = Custom;
	hypeDoc.currentSceneIndex = 0;
	hypeDoc.mainContentContainerID = "feed_hype_container";
	hypeDoc.resourcesFolderName = resourcesFolderName;
	hypeDoc.showHypeBuiltWatermark = 0;
	hypeDoc.showLoadingPage = false;
	hypeDoc.drawSceneBackgrounds = true;
	hypeDoc.documentName = documentName;

	HYPE.documents[documentName] = hypeDoc.API;

	hypeDoc.documentLoad(this.body);
}());

