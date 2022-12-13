#version 440 core

out vec4 colour;

in vec4 UVs;
in vec4 vColour;

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
		colour.a = 1.0;					//Note: If you're struggling with transparency in the future, this is why
		//if(colour.a == 0) discard;
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