#version 440 core

out vec4 color;

in vec4 UVs;

uniform sampler2D albedo;
uniform bool useTexture;

void main()
{
	if(useTexture)
	{
		color = texture(albedo, vec2(UVs));
		//if(color.a == 0) discard;
	}
	else
	{
		color = vec4(1.0, 0.0, 1.0, 1.0);
	}
}