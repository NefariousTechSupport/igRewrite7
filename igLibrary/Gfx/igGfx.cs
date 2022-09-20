/*
	"I'm just hoping we can get SF textures extracted soon, considering that's what we have leftover from shapeshifters"
		-Eon#9251 (User ID: 327591396343283713), 18/12/2021 at 16:22 GMT

	"i got textures from sg, stt, and ssc, ssf is pretty easy to add"
		-Neffy#5039 (User ID: 909500422006390874), 18/12/2021 at 16:23 GMT

	"if y'all want ssf texture extraction you're gonna have to cry cos this wayyy more complicated than i thought"
		-Neffy#5039 (User ID: 909500422006390874), 18/12/2021 at 18:33 GMT

	Why did you do this to me Eon?!
*/

namespace igLibrary.Gfx
{
	public static class igGfx
	{
		public static void Initialize()
		{
			igObjectDirectory metaimages = new igObjectDirectory();
			metaimages._useNameList = true;
			metaimages._name = new igName();
			metaimages._name.SetString("metaimages");
			metaimages._path = "metaimages";
			metaimages._objectList = new igObjectList();
			metaimages._nameList = new igNameList();

			#region ios
			igMetaImage pvrtc2_alpha = new igMetaImage();
			pvrtc2_alpha._bitsPerPixel = 2;
			pvrtc2_alpha._isSrgb = false;
			pvrtc2_alpha._isFloatingPoint = false;
			pvrtc2_alpha._isTile = false;
			pvrtc2_alpha._isCompressed = true;
			pvrtc2_alpha._isCanonical = true;
			pvrtc2_alpha._isFloatingPoint = false;
			pvrtc2_alpha._hasPalette = false;
			pvrtc2_alpha._name = "pvrtc2_alpha";
			pvrtc2_alpha._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha);
			metaimages._nameList.Append(new igName("pvrtc2_alpha"));

			igMetaImage pvrtc2_alpha_srgb = new igMetaImage();
			pvrtc2_alpha_srgb._bitsPerPixel = 2;
			pvrtc2_alpha_srgb._isSrgb = true;
			pvrtc2_alpha_srgb._isFloatingPoint = false;
			pvrtc2_alpha_srgb._isTile = false;
			pvrtc2_alpha_srgb._isCompressed = true;
			pvrtc2_alpha_srgb._isCanonical = true;
			pvrtc2_alpha_srgb._isFloatingPoint = false;
			pvrtc2_alpha_srgb._hasPalette = false;
			pvrtc2_alpha_srgb._name = "pvrtc2_alpha_srgb";
			pvrtc2_alpha_srgb._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_srgb);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_srgb"));

			igMetaImage pvrtc2_srgb = new igMetaImage();
			pvrtc2_srgb._bitsPerPixel = 2;
			pvrtc2_srgb._isSrgb = true;
			pvrtc2_srgb._isFloatingPoint = false;
			pvrtc2_srgb._isTile = false;
			pvrtc2_srgb._isCompressed = true;
			pvrtc2_srgb._isCanonical = true;
			pvrtc2_srgb._isFloatingPoint = false;
			pvrtc2_srgb._hasPalette = false;
			pvrtc2_srgb._name = "pvrtc2_srgb";
			pvrtc2_srgb._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_srgb);
			metaimages._nameList.Append(new igName("pvrtc2_srgb"));

			igMetaImage pvrtc2_alpha_metal = new igMetaImage();
			pvrtc2_alpha_metal._bitsPerPixel = 2;
			pvrtc2_alpha_metal._isSrgb = false;
			pvrtc2_alpha_metal._isFloatingPoint = false;
			pvrtc2_alpha_metal._isTile = false;
			pvrtc2_alpha_metal._isCompressed = true;
			pvrtc2_alpha_metal._isCanonical = true;
			pvrtc2_alpha_metal._isFloatingPoint = false;
			pvrtc2_alpha_metal._hasPalette = false;
			pvrtc2_alpha_metal._name = "pvrtc2_alpha_metal";
			pvrtc2_alpha_metal._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_metal);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_metal"));

			igMetaImage pvrtc2_alpha_srgb_metal = new igMetaImage();
			pvrtc2_alpha_srgb_metal._bitsPerPixel = 2;
			pvrtc2_alpha_srgb_metal._isSrgb = true;
			pvrtc2_alpha_srgb_metal._isFloatingPoint = false;
			pvrtc2_alpha_srgb_metal._isTile = false;
			pvrtc2_alpha_srgb_metal._isCompressed = true;
			pvrtc2_alpha_srgb_metal._isCanonical = true;
			pvrtc2_alpha_srgb_metal._isFloatingPoint = false;
			pvrtc2_alpha_srgb_metal._hasPalette = false;
			pvrtc2_alpha_srgb_metal._name = "pvrtc2_alpha_srgb_metal";
			pvrtc2_alpha_srgb_metal._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_srgb_metal);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_srgb_metal"));

			igMetaImage pvrtc2_metal = new igMetaImage();
			pvrtc2_metal._bitsPerPixel = 2;
			pvrtc2_metal._isSrgb = false;
			pvrtc2_metal._isFloatingPoint = false;
			pvrtc2_metal._isTile = false;
			pvrtc2_metal._isCompressed = true;
			pvrtc2_metal._isCanonical = true;
			pvrtc2_metal._isFloatingPoint = false;
			pvrtc2_metal._hasPalette = false;
			pvrtc2_metal._name = "pvrtc2_metal";
			pvrtc2_metal._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_metal);
			metaimages._nameList.Append(new igName("pvrtc2_metal"));

			igMetaImage pvrtc2_srgb_metal = new igMetaImage();
			pvrtc2_srgb_metal._bitsPerPixel = 2;
			pvrtc2_srgb_metal._isSrgb = true;
			pvrtc2_srgb_metal._isFloatingPoint = false;
			pvrtc2_srgb_metal._isTile = false;
			pvrtc2_srgb_metal._isCompressed = true;
			pvrtc2_srgb_metal._isCanonical = true;
			pvrtc2_srgb_metal._isFloatingPoint = false;
			pvrtc2_srgb_metal._hasPalette = false;
			pvrtc2_srgb_metal._name = "pvrtc2_srgb_metal";
			pvrtc2_srgb_metal._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_srgb_metal);
			metaimages._nameList.Append(new igName("pvrtc2_srgb_metal"));

			igMetaImage pvrtc2_alpha_android = new igMetaImage();
			pvrtc2_alpha_android._bitsPerPixel = 2;
			pvrtc2_alpha_android._isSrgb = false;
			pvrtc2_alpha_android._isFloatingPoint = false;
			pvrtc2_alpha_android._isTile = false;
			pvrtc2_alpha_android._isCompressed = true;
			pvrtc2_alpha_android._isCanonical = true;
			pvrtc2_alpha_android._isFloatingPoint = false;
			pvrtc2_alpha_android._hasPalette = false;
			pvrtc2_alpha_android._name = "pvrtc2_alpha_android";
			pvrtc2_alpha_android._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_android);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_android"));

			igMetaImage pvrtc2_alpha_aspen = new igMetaImage();
			pvrtc2_alpha_aspen._bitsPerPixel = 2;
			pvrtc2_alpha_aspen._isSrgb = false;
			pvrtc2_alpha_aspen._isFloatingPoint = false;
			pvrtc2_alpha_aspen._isTile = false;
			pvrtc2_alpha_aspen._isCompressed = true;
			pvrtc2_alpha_aspen._isCanonical = true;
			pvrtc2_alpha_aspen._isFloatingPoint = false;
			pvrtc2_alpha_aspen._hasPalette = false;
			pvrtc2_alpha_aspen._name = "pvrtc2_alpha_aspen";
			pvrtc2_alpha_aspen._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_aspen);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_aspen"));

			igMetaImage pvrtc2_alpha_lgtv = new igMetaImage();
			pvrtc2_alpha_lgtv._bitsPerPixel = 2;
			pvrtc2_alpha_lgtv._isSrgb = false;
			pvrtc2_alpha_lgtv._isFloatingPoint = false;
			pvrtc2_alpha_lgtv._isTile = false;
			pvrtc2_alpha_lgtv._isCompressed = true;
			pvrtc2_alpha_lgtv._isCanonical = true;
			pvrtc2_alpha_lgtv._isFloatingPoint = false;
			pvrtc2_alpha_lgtv._hasPalette = false;
			pvrtc2_alpha_lgtv._name = "pvrtc2_alpha_lgtv";
			pvrtc2_alpha_lgtv._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_lgtv);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_lgtv"));

			igMetaImage pvrtc2_alpha_argb_aspen = new igMetaImage();
			pvrtc2_alpha_argb_aspen._bitsPerPixel = 2;
			pvrtc2_alpha_argb_aspen._isSrgb = false;
			pvrtc2_alpha_argb_aspen._isFloatingPoint = false;
			pvrtc2_alpha_argb_aspen._isTile = false;
			pvrtc2_alpha_argb_aspen._isCompressed = true;
			pvrtc2_alpha_argb_aspen._isCanonical = true;
			pvrtc2_alpha_argb_aspen._isFloatingPoint = false;
			pvrtc2_alpha_argb_aspen._hasPalette = false;
			pvrtc2_alpha_argb_aspen._name = "pvrtc2_alpha_argb_aspen";
			pvrtc2_alpha_argb_aspen._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_argb_aspen);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_argb_aspen"));

			igMetaImage pvrtc2_android = new igMetaImage();
			pvrtc2_android._bitsPerPixel = 2;
			pvrtc2_android._isSrgb = false;
			pvrtc2_android._isFloatingPoint = false;
			pvrtc2_android._isTile = false;
			pvrtc2_android._isCompressed = true;
			pvrtc2_android._isCanonical = true;
			pvrtc2_android._isFloatingPoint = false;
			pvrtc2_android._hasPalette = false;
			pvrtc2_android._name = "pvrtc2_android";
			pvrtc2_android._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_android);
			metaimages._nameList.Append(new igName("pvrtc2_android"));

			igMetaImage pvrtc2_aspen = new igMetaImage();
			pvrtc2_aspen._bitsPerPixel = 2;
			pvrtc2_aspen._isSrgb = false;
			pvrtc2_aspen._isFloatingPoint = false;
			pvrtc2_aspen._isTile = false;
			pvrtc2_aspen._isCompressed = true;
			pvrtc2_aspen._isCanonical = true;
			pvrtc2_aspen._isFloatingPoint = false;
			pvrtc2_aspen._hasPalette = false;
			pvrtc2_aspen._name = "pvrtc2_aspen";
			pvrtc2_aspen._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_aspen);
			metaimages._nameList.Append(new igName("pvrtc2_aspen"));

			igMetaImage pvrtc2_lgtv = new igMetaImage();
			pvrtc2_lgtv._bitsPerPixel = 2;
			pvrtc2_lgtv._isSrgb = false;
			pvrtc2_lgtv._isFloatingPoint = false;
			pvrtc2_lgtv._isTile = false;
			pvrtc2_lgtv._isCompressed = true;
			pvrtc2_lgtv._isCanonical = true;
			pvrtc2_lgtv._isFloatingPoint = false;
			pvrtc2_lgtv._hasPalette = false;
			pvrtc2_lgtv._name = "pvrtc2_lgtv";
			pvrtc2_lgtv._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_lgtv);
			metaimages._nameList.Append(new igName("pvrtc2_lgtv"));

			igMetaImage pvrtc2_srgb_aspen = new igMetaImage();
			pvrtc2_srgb_aspen._bitsPerPixel = 2;
			pvrtc2_srgb_aspen._isSrgb = true;
			pvrtc2_srgb_aspen._isFloatingPoint = false;
			pvrtc2_srgb_aspen._isTile = false;
			pvrtc2_srgb_aspen._isCompressed = true;
			pvrtc2_srgb_aspen._isCanonical = true;
			pvrtc2_srgb_aspen._isFloatingPoint = false;
			pvrtc2_srgb_aspen._hasPalette = false;
			pvrtc2_srgb_aspen._name = "pvrtc2_srgb_aspen";
			pvrtc2_srgb_aspen._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_srgb_aspen);
			metaimages._nameList.Append(new igName("pvrtc2_srgb_aspen"));

			#endregion

			#region ps3

			igMetaImage dxt1_big_ps3 = new igMetaImage();
			dxt1_big_ps3._bitsPerPixel = 2;
			dxt1_big_ps3._isSrgb = false;
			dxt1_big_ps3._isFloatingPoint = false;
			dxt1_big_ps3._isTile = false;
			dxt1_big_ps3._isCompressed = true;
			dxt1_big_ps3._isCanonical = true;
			dxt1_big_ps3._isFloatingPoint = false;
			dxt1_big_ps3._hasPalette = false;
			dxt1_big_ps3._name = "dxt1_big_ps3";
			dxt1_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt1_generic);
			metaimages._objectList.Append(dxt1_big_ps3);
			metaimages._nameList.Append(new igName("dxt1_big_ps3"));

			igMetaImage dxt1_srgb_big_ps3 = new igMetaImage();
			dxt1_srgb_big_ps3._bitsPerPixel = 2;
			dxt1_srgb_big_ps3._isSrgb = true;
			dxt1_srgb_big_ps3._isFloatingPoint = false;
			dxt1_srgb_big_ps3._isTile = false;
			dxt1_srgb_big_ps3._isCompressed = true;
			dxt1_srgb_big_ps3._isCanonical = true;
			dxt1_srgb_big_ps3._isFloatingPoint = false;
			dxt1_srgb_big_ps3._hasPalette = false;
			dxt1_srgb_big_ps3._name = "dxt1_srgb_big_ps3";
			dxt1_srgb_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt1_generic);
			metaimages._objectList.Append(dxt1_srgb_big_ps3);
			metaimages._nameList.Append(new igName("dxt1_srgb_big_ps3"));

			igMetaImage dxt1_tile_big_ps3 = new igMetaImage();
			dxt1_tile_big_ps3._bitsPerPixel = 2;
			dxt1_tile_big_ps3._isSrgb = false;
			dxt1_tile_big_ps3._isFloatingPoint = false;
			dxt1_tile_big_ps3._isTile = true;
			dxt1_tile_big_ps3._isCompressed = true;
			dxt1_tile_big_ps3._isCanonical = true;
			dxt1_tile_big_ps3._isFloatingPoint = false;
			dxt1_tile_big_ps3._hasPalette = false;
			dxt1_tile_big_ps3._name = "dxt1_tile_big_ps3";
			dxt1_tile_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt1_generic);
			metaimages._objectList.Append(dxt1_tile_big_ps3);
			metaimages._nameList.Append(new igName("dxt1_tile_big_ps3"));

			igMetaImage dxt1_srgb_tile_big_ps3 = new igMetaImage();
			dxt1_srgb_tile_big_ps3._bitsPerPixel = 2;
			dxt1_srgb_tile_big_ps3._isSrgb = true;
			dxt1_srgb_tile_big_ps3._isFloatingPoint = false;
			dxt1_srgb_tile_big_ps3._isTile = true;
			dxt1_srgb_tile_big_ps3._isCompressed = true;
			dxt1_srgb_tile_big_ps3._isCanonical = true;
			dxt1_srgb_tile_big_ps3._isFloatingPoint = false;
			dxt1_srgb_tile_big_ps3._hasPalette = false;
			dxt1_srgb_tile_big_ps3._name = "dxt1_srgb_tile_big_ps3";
			dxt1_srgb_tile_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt1_generic);
			metaimages._objectList.Append(dxt1_srgb_tile_big_ps3);
			metaimages._nameList.Append(new igName("dxt1_srgb_tile_big_ps3"));

			igMetaImage dxt3_big_ps3 = new igMetaImage();
			dxt3_big_ps3._bitsPerPixel = 4;
			dxt3_big_ps3._isSrgb = false;
			dxt3_big_ps3._isFloatingPoint = false;
			dxt3_big_ps3._isTile = false;
			dxt3_big_ps3._isCompressed = true;
			dxt3_big_ps3._isCanonical = true;
			dxt3_big_ps3._isFloatingPoint = false;
			dxt3_big_ps3._hasPalette = false;
			dxt3_big_ps3._name = "dxt3_big_ps3";
			dxt3_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt3_generic);
			metaimages._objectList.Append(dxt3_big_ps3);
			metaimages._nameList.Append(new igName("dxt3_big_ps3"));

			igMetaImage dxt3_srgb_big_ps3 = new igMetaImage();
			dxt3_srgb_big_ps3._bitsPerPixel = 4;
			dxt3_srgb_big_ps3._isSrgb = true;
			dxt3_srgb_big_ps3._isFloatingPoint = false;
			dxt3_srgb_big_ps3._isTile = false;
			dxt3_srgb_big_ps3._isCompressed = true;
			dxt3_srgb_big_ps3._isCanonical = true;
			dxt3_srgb_big_ps3._isFloatingPoint = false;
			dxt3_srgb_big_ps3._hasPalette = false;
			dxt3_srgb_big_ps3._name = "dxt3_srgb_big_ps3";
			dxt3_srgb_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt3_generic);
			metaimages._objectList.Append(dxt3_srgb_big_ps3);
			metaimages._nameList.Append(new igName("dxt3_srgb_big_ps3"));

			igMetaImage dxt3_tile_big_ps3 = new igMetaImage();
			dxt3_tile_big_ps3._bitsPerPixel = 4;
			dxt3_tile_big_ps3._isSrgb = false;
			dxt3_tile_big_ps3._isFloatingPoint = false;
			dxt3_tile_big_ps3._isTile = true;
			dxt3_tile_big_ps3._isCompressed = true;
			dxt3_tile_big_ps3._isCanonical = true;
			dxt3_tile_big_ps3._isFloatingPoint = false;
			dxt3_tile_big_ps3._hasPalette = false;
			dxt3_tile_big_ps3._name = "dxt3_tile_big_ps3";
			dxt3_tile_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt3_generic);
			metaimages._objectList.Append(dxt3_tile_big_ps3);
			metaimages._nameList.Append(new igName("dxt3_tile_big_ps3"));

			igMetaImage dxt3_srgb_tile_big_ps3 = new igMetaImage();
			dxt3_srgb_tile_big_ps3._bitsPerPixel = 4;
			dxt3_srgb_tile_big_ps3._isSrgb = true;
			dxt3_srgb_tile_big_ps3._isFloatingPoint = false;
			dxt3_srgb_tile_big_ps3._isTile = true;
			dxt3_srgb_tile_big_ps3._isCompressed = true;
			dxt3_srgb_tile_big_ps3._isCanonical = true;
			dxt3_srgb_tile_big_ps3._isFloatingPoint = false;
			dxt3_srgb_tile_big_ps3._hasPalette = false;
			dxt3_srgb_tile_big_ps3._name = "dxt3_srgb_tile_big_ps3";
			dxt3_srgb_tile_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt3_generic);
			metaimages._objectList.Append(dxt3_srgb_tile_big_ps3);
			metaimages._nameList.Append(new igName("dxt3_srgb_tile_big_ps3"));

			igMetaImage dxt5_big_ps3 = new igMetaImage();
			dxt5_big_ps3._bitsPerPixel = 4;
			dxt5_big_ps3._isSrgb = false;
			dxt5_big_ps3._isFloatingPoint = false;
			dxt5_big_ps3._isTile = false;
			dxt5_big_ps3._isCompressed = true;
			dxt5_big_ps3._isCanonical = true;
			dxt5_big_ps3._isFloatingPoint = false;
			dxt5_big_ps3._hasPalette = false;
			dxt5_big_ps3._name = "dxt5_big_ps3";
			dxt5_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt5_generic);
			metaimages._objectList.Append(dxt5_big_ps3);
			metaimages._nameList.Append(new igName("dxt5_big_ps3"));

			igMetaImage dxt5_srgb_big_ps3 = new igMetaImage();
			dxt5_srgb_big_ps3._bitsPerPixel = 4;
			dxt5_srgb_big_ps3._isSrgb = true;
			dxt5_srgb_big_ps3._isFloatingPoint = false;
			dxt5_srgb_big_ps3._isTile = false;
			dxt5_srgb_big_ps3._isCompressed = true;
			dxt5_srgb_big_ps3._isCanonical = true;
			dxt5_srgb_big_ps3._isFloatingPoint = false;
			dxt5_srgb_big_ps3._hasPalette = false;
			dxt5_srgb_big_ps3._name = "dxt5_srgb_big_ps3";
			dxt5_srgb_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt5_generic);
			metaimages._objectList.Append(dxt5_srgb_big_ps3);
			metaimages._nameList.Append(new igName("dxt5_srgb_big_ps3"));

			igMetaImage dxt5_tile_big_ps3 = new igMetaImage();
			dxt5_tile_big_ps3._bitsPerPixel = 4;
			dxt5_tile_big_ps3._isSrgb = false;
			dxt5_tile_big_ps3._isFloatingPoint = false;
			dxt5_tile_big_ps3._isTile = true;
			dxt5_tile_big_ps3._isCompressed = true;
			dxt5_tile_big_ps3._isCanonical = true;
			dxt5_tile_big_ps3._isFloatingPoint = false;
			dxt5_tile_big_ps3._hasPalette = false;
			dxt5_tile_big_ps3._name = "dxt5_tile_big_ps3";
			dxt5_tile_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt5_generic);
			metaimages._objectList.Append(dxt5_tile_big_ps3);
			metaimages._nameList.Append(new igName("dxt5_tile_big_ps3"));

			igMetaImage dxt5_srgb_tile_big_ps3 = new igMetaImage();
			dxt5_srgb_tile_big_ps3._bitsPerPixel = 4;
			dxt5_srgb_tile_big_ps3._isSrgb = true;
			dxt5_srgb_tile_big_ps3._isFloatingPoint = false;
			dxt5_srgb_tile_big_ps3._isTile = true;
			dxt5_srgb_tile_big_ps3._isCompressed = true;
			dxt5_srgb_tile_big_ps3._isCanonical = true;
			dxt5_srgb_tile_big_ps3._isFloatingPoint = false;
			dxt5_srgb_tile_big_ps3._hasPalette = false;
			dxt5_srgb_tile_big_ps3._name = "dxt5_srgb_tile_big_ps3";
			dxt5_srgb_tile_big_ps3._functions.Add(igMetaImage.igImage2Conversion_dxt5_generic);
			metaimages._objectList.Append(dxt5_srgb_tile_big_ps3);
			metaimages._nameList.Append(new igName("dxt5_srgb_tile_big_ps3"));

			#endregion

			igObjectStreamManager.Singleton.AddObjectDirectory(metaimages);
		}
	}
}