#version 330 core

out vec4 outputColor;

uniform vec3 Color;

void main(){
	outputColor = vec4(Color, 1.0);
} 