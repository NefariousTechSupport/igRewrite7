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
			//metaimages._objectList = new igObjectList();
			metaimages._nameList = new igNameList();

			//                             srgb, float,  tile,  comp, canon, pallette

			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_alpha");
			AddMetaImage(metaimages, 002,  true, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_alpha_srgb");
			AddMetaImage(metaimages, 002,  true, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_srgb");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_alpha_metal");
			AddMetaImage(metaimages, 002,  true, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_alpha_srgb_metal");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_metal");
			AddMetaImage(metaimages, 002,  true, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_srgb_metal");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_alpha_aspen");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_alpha_android");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_alpha_lgtv");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_alpha_argb_aspen");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_android");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_aspen");
			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_lgtv");
			AddMetaImage(metaimages, 002,  true, false, false,  true,  true, false, igMetaImage.igImage2Conversion_pvrtc2_generic, "pvrtc2_srgb_aspen");

			//                             srgb, float,  tile,  comp, canon, pallette

			AddMetaImage(metaimages, 002, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_dxt1_generic, "dxt1_big_ps3");
			AddMetaImage(metaimages, 002,  true, false, false,  true,  true, false, igMetaImage.igImage2Conversion_dxt1_generic, "dxt1_srgb_big_ps3");
			AddMetaImage(metaimages, 002, false, false,  true,  true,  true, false, igMetaImage.igImage2Conversion_dxt1_generic, "dxt1_tile_big_ps3");
			AddMetaImage(metaimages, 002,  true, false,  true,  true,  true, false, igMetaImage.igImage2Conversion_dxt1_generic, "dxt1_srgb_tile_big_ps3");

			AddMetaImage(metaimages, 004, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_dxt3_generic, "dxt3_big_ps3");
			AddMetaImage(metaimages, 004,  true, false, false,  true,  true, false, igMetaImage.igImage2Conversion_dxt3_generic, "dxt3_srgb_big_ps3");
			AddMetaImage(metaimages, 004, false, false,  true,  true,  true, false, igMetaImage.igImage2Conversion_dxt3_generic, "dxt3_tile_big_ps3");
			AddMetaImage(metaimages, 004,  true, false,  true,  true,  true, false, igMetaImage.igImage2Conversion_dxt3_generic, "dxt3_srgb_tile_big_ps3");

			AddMetaImage(metaimages, 004, false, false, false,  true,  true, false, igMetaImage.igImage2Conversion_dxt5_generic, "dxt5_big_ps3");
			AddMetaImage(metaimages, 004,  true, false, false,  true,  true, false, igMetaImage.igImage2Conversion_dxt5_generic, "dxt5_srgb_big_ps3");
			AddMetaImage(metaimages, 004, false, false,  true,  true,  true, false, igMetaImage.igImage2Conversion_dxt5_generic, "dxt5_tile_big_ps3");
			AddMetaImage(metaimages, 004,  true, false,  true,  true,  true, false, igMetaImage.igImage2Conversion_dxt5_generic, "dxt5_srgb_tile_big_ps3");

			//                             srgb, float,  tile,  comp, canon, pallette

			igObjectStreamManager.Singleton.AddObjectDirectory(metaimages);
		}

		private static void AddMetaImage(igObjectDirectory metaimages, byte bpp, bool srgb, bool fp, bool tile, bool comp, bool canon, bool palette, Func<igMemory, ushort, ushort, ushort, byte[]> convertFunc, string name)
		{
			igMetaImage metaimage = new igMetaImage();
			metaimage._bitsPerPixel = bpp;
			metaimage._isSrgb = srgb;
			metaimage._isFloatingPoint = fp;
			metaimage._isTile = tile;
			metaimage._isCompressed = comp;
			metaimage._isCanonical = canon;
			metaimage._hasPalette = palette;
			metaimage._name = name;
			metaimage._functions.Add(convertFunc);
			metaimages._objectList.Append(metaimage);
			metaimages._nameList.Append(new igName(name));
		}
	}
}