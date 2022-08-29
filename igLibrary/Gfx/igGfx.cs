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

			igMetaImage pvrtc2_alpha = new igMetaImage();
			pvrtc2_alpha._bitsPerPixel = 2;
			pvrtc2_alpha._isSrgb = false;
			pvrtc2_alpha._isFloatingPoint = false;
			pvrtc2_alpha._isTile = false;
			pvrtc2_alpha._name = "pvrtc2_alpha";
			pvrtc2_alpha._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha);
			metaimages._nameList.Append(new igName("pvrtc2_alpha"));

			igMetaImage pvrtc2_alpha_srgb = new igMetaImage();
			pvrtc2_alpha_srgb._bitsPerPixel = 2;
			pvrtc2_alpha_srgb._isSrgb = true;
			pvrtc2_alpha_srgb._isFloatingPoint = false;
			pvrtc2_alpha_srgb._isTile = false;
			pvrtc2_alpha_srgb._name = "pvrtc2_alpha_srgb";
			pvrtc2_alpha_srgb._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_srgb);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_srgb"));

			igMetaImage pvrtc2_srgb = new igMetaImage();
			pvrtc2_srgb._bitsPerPixel = 2;
			pvrtc2_srgb._isSrgb = true;
			pvrtc2_srgb._isFloatingPoint = false;
			pvrtc2_srgb._isTile = false;
			pvrtc2_srgb._name = "pvrtc2_srgb";
			pvrtc2_srgb._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_srgb);
			metaimages._nameList.Append(new igName("pvrtc2_srgb"));

			igMetaImage pvrtc2_alpha_metal = new igMetaImage();
			pvrtc2_alpha_metal._bitsPerPixel = 2;
			pvrtc2_alpha_metal._isSrgb = false;
			pvrtc2_alpha_metal._isFloatingPoint = false;
			pvrtc2_alpha_metal._isTile = false;
			pvrtc2_alpha_metal._name = "pvrtc2_alpha_metal";
			pvrtc2_alpha_metal._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_metal);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_metal"));

			igMetaImage pvrtc2_alpha_srgb_metal = new igMetaImage();
			pvrtc2_alpha_srgb_metal._bitsPerPixel = 2;
			pvrtc2_alpha_srgb_metal._isSrgb = true;
			pvrtc2_alpha_srgb_metal._isFloatingPoint = false;
			pvrtc2_alpha_srgb_metal._isTile = false;
			pvrtc2_alpha_srgb_metal._name = "pvrtc2_alpha_srgb_metal";
			pvrtc2_alpha_srgb_metal._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_srgb_metal);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_srgb_metal"));

			igMetaImage pvrtc2_metal = new igMetaImage();
			pvrtc2_metal._bitsPerPixel = 2;
			pvrtc2_metal._isSrgb = false;
			pvrtc2_metal._isFloatingPoint = false;
			pvrtc2_metal._isTile = false;
			pvrtc2_metal._name = "pvrtc2_metal";
			pvrtc2_metal._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_metal);
			metaimages._nameList.Append(new igName("pvrtc2_metal"));

			igMetaImage pvrtc2_srgb_metal = new igMetaImage();
			pvrtc2_srgb_metal._bitsPerPixel = 2;
			pvrtc2_srgb_metal._isSrgb = true;
			pvrtc2_srgb_metal._isFloatingPoint = false;
			pvrtc2_srgb_metal._isTile = false;
			pvrtc2_srgb_metal._name = "pvrtc2_srgb_metal";
			pvrtc2_srgb_metal._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_srgb_metal);
			metaimages._nameList.Append(new igName("pvrtc2_srgb_metal"));

			igMetaImage pvrtc2_alpha_android = new igMetaImage();
			pvrtc2_alpha_android._bitsPerPixel = 2;
			pvrtc2_alpha_android._isSrgb = false;
			pvrtc2_alpha_android._isFloatingPoint = false;
			pvrtc2_alpha_android._isTile = false;
			pvrtc2_alpha_android._name = "pvrtc2_alpha_android";
			pvrtc2_alpha_android._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_android);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_android"));

			igMetaImage pvrtc2_alpha_aspen = new igMetaImage();
			pvrtc2_alpha_aspen._bitsPerPixel = 2;
			pvrtc2_alpha_aspen._isSrgb = false;
			pvrtc2_alpha_aspen._isFloatingPoint = false;
			pvrtc2_alpha_aspen._isTile = false;
			pvrtc2_alpha_aspen._name = "pvrtc2_alpha_aspen";
			pvrtc2_alpha_aspen._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_aspen);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_aspen"));

			igMetaImage pvrtc2_alpha_lgtv = new igMetaImage();
			pvrtc2_alpha_lgtv._bitsPerPixel = 2;
			pvrtc2_alpha_lgtv._isSrgb = false;
			pvrtc2_alpha_lgtv._isFloatingPoint = false;
			pvrtc2_alpha_lgtv._isTile = false;
			pvrtc2_alpha_lgtv._name = "pvrtc2_alpha_lgtv";
			pvrtc2_alpha_lgtv._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_lgtv);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_lgtv"));

			igMetaImage pvrtc2_alpha_argb_aspen = new igMetaImage();
			pvrtc2_alpha_argb_aspen._bitsPerPixel = 2;
			pvrtc2_alpha_argb_aspen._isSrgb = false;
			pvrtc2_alpha_argb_aspen._isFloatingPoint = false;
			pvrtc2_alpha_argb_aspen._isTile = false;
			pvrtc2_alpha_argb_aspen._name = "pvrtc2_alpha_argb_aspen";
			pvrtc2_alpha_argb_aspen._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_alpha_argb_aspen);
			metaimages._nameList.Append(new igName("pvrtc2_alpha_argb_aspen"));

			igMetaImage pvrtc2_android = new igMetaImage();
			pvrtc2_android._bitsPerPixel = 2;
			pvrtc2_android._isSrgb = false;
			pvrtc2_android._isFloatingPoint = false;
			pvrtc2_android._isTile = false;
			pvrtc2_android._name = "pvrtc2_android";
			pvrtc2_android._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_android);
			metaimages._nameList.Append(new igName("pvrtc2_android"));

			igMetaImage pvrtc2_aspen = new igMetaImage();
			pvrtc2_aspen._bitsPerPixel = 2;
			pvrtc2_aspen._isSrgb = false;
			pvrtc2_aspen._isFloatingPoint = false;
			pvrtc2_aspen._isTile = false;
			pvrtc2_aspen._name = "pvrtc2_aspen";
			pvrtc2_aspen._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_aspen);
			metaimages._nameList.Append(new igName("pvrtc2_aspen"));

			igMetaImage pvrtc2_lgtv = new igMetaImage();
			pvrtc2_lgtv._bitsPerPixel = 2;
			pvrtc2_lgtv._isSrgb = false;
			pvrtc2_lgtv._isFloatingPoint = false;
			pvrtc2_lgtv._isTile = false;
			pvrtc2_lgtv._name = "pvrtc2_lgtv";
			pvrtc2_lgtv._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_lgtv);
			metaimages._nameList.Append(new igName("pvrtc2_lgtv"));

			igMetaImage pvrtc2_srgb_aspen = new igMetaImage();
			pvrtc2_srgb_aspen._bitsPerPixel = 2;
			pvrtc2_srgb_aspen._isSrgb = true;
			pvrtc2_srgb_aspen._isFloatingPoint = false;
			pvrtc2_srgb_aspen._isTile = false;
			pvrtc2_srgb_aspen._name = "pvrtc2_srgb_aspen";
			pvrtc2_srgb_aspen._functions.Add(igMetaImage.igImage2Conversion_pvrtc2_generic);
			metaimages._objectList.Append(pvrtc2_srgb_aspen);
			metaimages._nameList.Append(new igName("pvrtc2_srgb_aspen"));

			igObjectStreamManager.Singleton.AddObjectDirectory(metaimages);
		}
	}
}