#version 440 core

out vec4 colour;

in vec4 UVs;
in vec4 vColour;

uniform bool standard_vertexWibbleEnabled;
uniform bool standard_hasEmissiveMap;
uniform bool standard_anisotropicShading;
uniform bool standard_iridescentEnabled;
uniform vec4 standard_parallaxParams;
uniform bool standard_useVertAlphaAsHeight;
uniform bool standard_useVertColorAsHeight;
uniform bool standard_flipVertAlphaHeight;
uniform float standard_normalMapScale;
uniform bool standard_additive;
uniform vec4 ig_color_value;
uniform vec4 ig_matrix_texture;
uniform bool ig_blending_enable;
uniform bool ig_cullface_enable;

uniform sampler2D albedo;
uniform bool useTexture;
uniform bool useVColour;

void main()
{
	if(useTexture)
	{
		colour = texture(albedo, vec2(UVs));
		if(useVColour)
		{
			colour *= vColour;
		}
		colour *= ig_color_value;
		//if(colour.a == 0) discard;
		colour.a = 1.0;					//Note: If you're struggling with transparency in the future, this is why
	}
	else
	{
		colour = vec4(1.0, 0.0, 1.0, 1.0);
		if(useVColour)
		{
			colour = vColour;
		}
	}
}