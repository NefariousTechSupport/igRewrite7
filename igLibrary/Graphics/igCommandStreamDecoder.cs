namespace igLibrary.Graphics
{
	//This has fields and inherits from igObject but it should never be written to a while so who cares 
	public class igCommandStreamDecoder
	{
		public static Action NoopCommand = () => {};
		public static Action<IG_GFX_DRAW> SetPrimitiveTypeCommand = (a) => {};
		public static Action<ulong, ulong, uint, uint> SetVertexBufferCommand = (a, b, c, d) => {};
		public static Action<ulong, IG_INDEX_TYPE, uint> SetIndexBufferCommand = (a, b, c) => {};
		public static Action<ulong> SetVertexShaderCommand = (a) => {};
		public static Action<ulong> SetVertexShaderVariantCommand = (a) => {};
		public static Action<ulong, uint> SetVertexShaderTextureCommand = (a, b) => {};
		public static Action<ulong, uint> SetVertexShaderSamplerCommand = (a, b) => {};
		public static Action<int, int, int, int, float, float> SetViewportCommand = (a, b, c, d, e, f) => {};
		public static Action<int, int, int, int> SetScissorCommand = (a, b, c, d) => {};
		public static Action<bool> SetScissorEnabledCommand = (a) => {};
		public static Action<ulong> SetRasterizeStateBundleCommand = (a) => {};
		public static Action<ulong> SetPixelShaderCommand = (a) => {};
		public static Action<ulong> SetPixelShaderVariantCommand = (a) => {};
		public static Action<ulong, uint> SetPixelShaderTextureCommand = (a, b) => {};
		public static Action<ulong, uint> SetPixelShaderSamplerCommand = (a, b) => {};
		public static Action SetAlphaTestStateBundleCommand = () => {};
		public static Action<ulong> SetBlendStateBundleCommand = (a) => {};
		public static Action<ulong> SetDepthStateBundleCommand = (a) => {};
		public static Action<ulong> SetStencilStateBundleCommand = (a) => {};
		public static Action<uint> SetStencilRefCommand = (a) => {};
		public static Action<ulong, uint, ulong> SetRenderTargetsCommand = (a, b, c) => {};
		public static Action<ulong> SetRenderTargetMaskCommand = (a) => {};
		public static Action<ulong, bool> SetConstantBoolCommand = (a, b) => {};
		public static Action<ulong, int> SetConstantIntCommand = (a, b) => {};
		public static Action<ulong, float> SetConstantFloatCommand = (a, b) => {};
		public static Action<ulong, Vector4> SetConstantVec4fCommand = (a, b) => {};
		public static Action<ulong, Matrix4x4> SetConstantMatrix44fCommand = (a, b) => {};
		public static Action<ulong, int[], int> SetConstantArrayIntCommand = (a, b, c) => {};
		public static Action<ulong, float[], int> SetConstantArrayFloatCommand = (a, b, c) => {};
		public static Action<ulong, Vector4[], int> SetConstantArrayVec4fCommand = (a, b, c) => {};
		public static Action<ulong, Matrix4x4[], int> SetConstantArrayMatrix44fCommand = (a, b, c) => {};

		private StreamHelper? sh;

		public unsafe void Decode(igCommandStream commandStream)
		{
			if(sh == null)
			{
				if(commandStream is igMemoryCommandStream memoryCommandStream)
				{
					sh = new StreamHelper(memoryCommandStream._memory.buffer, (igCore.IsPlatformBigEndian(igCore.platform) ? StreamHelper.Endianness.Big : StreamHelper.Endianness.Little));
				}
				else throw new NotImplementedException($"{commandStream.GetType()} isn't supported for decoding");
			}

			Func<ulong> readPointer = () => sh.ReadUInt32();
			if(igCore.IsPlatform64Bit(igCore.platform))
			{
				readPointer = () => sh.ReadUInt64();
			}
			byte sizeOfPointer = igCore.GetSizeOfPointer(igCore.platform);

			sh.Seek(0);

			while(true)
			{
				if((sh.BaseStream.Length - sh.Tell()) < 4) break;

				sh.Align(4);

				igCommandId id = (igCommandId)sh.ReadUInt32();
				switch(id)
				{
					case igCommandId.kSetPrimitiveType:
						sh.Align(4);
						SetPrimitiveTypeCommand.Invoke((IG_GFX_DRAW)sh.ReadUInt32());
						break;
					case igCommandId.kSetVertexBuffer:
						sh.Align(sizeOfPointer);
						SetVertexBufferCommand.Invoke(readPointer(), readPointer(), sh.ReadUInt32(), sh.ReadUInt32());
						break;
					case igCommandId.kSetIndexBuffer:
						sh.Align(sizeOfPointer);
						SetIndexBufferCommand.Invoke(readPointer(), (IG_INDEX_TYPE)sh.ReadUInt32(), sh.ReadUInt32());
						break;
					case igCommandId.kSetVertexShader:
						sh.Align(sizeOfPointer);
						SetVertexShaderCommand.Invoke(readPointer());
						break;
					case igCommandId.kSetVertexShaderVariant:
						sh.Align(sizeOfPointer);
						SetVertexShaderVariantCommand.Invoke(readPointer());
						break;
					case igCommandId.kSetVertexShaderTexture:
						sh.Align(sizeOfPointer);
						SetVertexShaderTextureCommand.Invoke(readPointer(), sh.ReadUInt32());
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetVertexShaderSampler:
						sh.Align(sizeOfPointer);
						SetVertexShaderSamplerCommand.Invoke(readPointer(), sh.ReadUInt32());
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetViewport:
						sh.Align(4);
						SetViewportCommand.Invoke(sh.ReadInt32(), sh.ReadInt32(), sh.ReadInt32(), sh.ReadInt32(), sh.ReadSingle(), sh.ReadSingle());
						break;
					case igCommandId.kSetScissor:
						sh.Align(4);
						SetScissorCommand.Invoke(sh.ReadInt32(), sh.ReadInt32(), sh.ReadInt32(), sh.ReadInt32());
						break;
					case igCommandId.kSetScissorEnabled:
						SetScissorEnabledCommand.Invoke(sh.ReadBoolean());
						break;
					case igCommandId.kSetRasterizeStateBundle:
						sh.Align(sizeOfPointer);
						SetRasterizeStateBundleCommand.Invoke(readPointer());
						break;
					case igCommandId.kSetPixelShader:
						sh.Align(sizeOfPointer);
						SetPixelShaderCommand.Invoke(readPointer());
						break;
					case igCommandId.kSetPixelShaderVariant:
						sh.Align(sizeOfPointer);
						SetPixelShaderVariantCommand.Invoke(readPointer());
						break;
					case igCommandId.kSetPixelShaderTexture:
						sh.Align(sizeOfPointer);
						SetPixelShaderTextureCommand.Invoke(readPointer(), sh.ReadUInt32());
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetPixelShaderSampler:
						sh.Align(sizeOfPointer);
						SetPixelShaderSamplerCommand.Invoke(readPointer(), sh.ReadUInt32());
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetAlphaTestStateBundle:
						sh.Align(sizeOfPointer);
						readPointer();
						SetAlphaTestStateBundleCommand.Invoke();
						break;
					case igCommandId.kSetBlendStateBundle:
						sh.Align(sizeOfPointer);
						SetBlendStateBundleCommand.Invoke(readPointer());
						break;
					case igCommandId.kSetDepthStateBundle:
						sh.Align(sizeOfPointer);
						SetDepthStateBundleCommand.Invoke(readPointer());
						break;
					case igCommandId.kSetStencilStateBundle:
						sh.Align(sizeOfPointer);
						SetStencilStateBundleCommand.Invoke(readPointer());
						break;
					case igCommandId.kSetStencilRef:
						sh.Align(4);
						SetStencilRefCommand.Invoke(sh.ReadUInt32());
						break;
					case igCommandId.kSetRenderTargets:
						/*sh.Align(8);
						ulong setRenderTargetsVar1 = sh.ReadUInt64();
						sh.Seek(0x38, SeekOrigin.Current);
						uint setRenderTargetsVar2 = sh.ReadUInt32();
						sh.Seek(0x04, SeekOrigin.Current);
						ulong setRenderTargetsVar3 = sh.ReadUInt64();
						SetRenderTargetsCommand.Invoke(setRenderTargetsVar1, setRenderTargetsVar2, setRenderTargetsVar3);*/
						sh.Align(sizeOfPointer);
						if(sizeOfPointer == 8) sh.Seek(0x50, SeekOrigin.Current);
						else                   sh.Seek(0x28, SeekOrigin.Current);	//Guessed
						break;
					case igCommandId.kSetRenderTargetMask:
						sh.Align(8);
						SetRenderTargetMaskCommand.Invoke(sh.ReadUInt64());
						break;
					//The following don't have commands since they're platform specific, we're just gonna skip right past them
					case igCommandId.kXenonSetHiStencil:
					case igCommandId.kPS3SetSCull:
						sh.Align(4);
						sh.Seek(0x0C, SeekOrigin.Current);
						break;
					case igCommandId.kXenonFlushHiZStencil:
						sh.ReadByte();
						break;
					case igCommandId.kXenonSetGprCounts:
						sh.Align(4);
						sh.Seek(0x08, SeekOrigin.Current);
						break;
					case igCommandId.kPS3DrawEdgeGeometry:
						sh.Align(8);
						sh.Seek(0x38, SeekOrigin.Current);
						break;
					//end of platform specific stuff
					case igCommandId.kSetConstantBool:
						sh.Align(sizeOfPointer);
						SetConstantBoolCommand.Invoke(readPointer(), readPointer() == 0 ? false : true);
						break;
					case igCommandId.kSetConstantInt:
						sh.Align(sizeOfPointer);
						SetConstantIntCommand.Invoke(readPointer(), sh.ReadInt32());
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetConstantFloat:
						sh.Align(sizeOfPointer);
						SetConstantFloatCommand.Invoke(readPointer(), sh.ReadSingle());
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetConstantVec4f:
						sh.Align(16);
						ulong setConstantVec4fVar1 = readPointer();
						sh.Align(16);
						Vector4 setConstantVec4fVar2 = sh.ReadStruct<Vector4>();
						SetConstantVec4fCommand.Invoke(setConstantVec4fVar1, setConstantVec4fVar2);
						break;
					case igCommandId.kSetConstantMatrix44f:
						sh.Align(16);
						ulong setConstantMatrix44fVar1 = readPointer();
						sh.Align(16);
						Matrix4x4 setConstantMatrix44fVar2 = sh.ReadStruct<Matrix4x4>();
						SetConstantMatrix44fCommand.Invoke(setConstantMatrix44fVar1, setConstantMatrix44fVar2);
						break;
					case igCommandId.kSetConstantArrayInt:
						sh.Align(sizeOfPointer);
						SetConstantArrayIntCommand.Invoke(readPointer(), new int[]{ (int)readPointer() }, sh.ReadInt32());	//Placeholders are fun
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetConstantArrayFloat:
						sh.Align(sizeOfPointer);
						SetConstantArrayFloatCommand.Invoke(readPointer(), new float[] { readPointer() }, sh.ReadInt32());	//Placeholders are fun
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetConstantArrayVec4f:
						sh.Align(sizeOfPointer);
						SetConstantArrayVec4fCommand.Invoke(readPointer(), new Vector4[] { new Vector4(readPointer()) }, sh.ReadInt32());	//Placeholders are fun
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kSetConstantArrayMatrix44f:
						sh.Align(sizeOfPointer);
						SetConstantArrayMatrix44fCommand.Invoke(readPointer(), new Matrix4x4[] { Matrix4x4.CreateScale(readPointer()) }, sh.ReadInt32());	//Placeholders are fun
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kApplyConstantBundle:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer, SeekOrigin.Current);	//It called code, i don't want to deal with that
						break;
					case igCommandId.kApplyConstantValueList:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer, SeekOrigin.Current);	//Looks complicated, i don't want to deal with that
						break;
					case igCommandId.kSetPixelShaderTextureEnabledConstant:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer * 2);
						//getPixelShaderTexture(secondValue);
						//Set constant at firstValue to true if above returns non-null
						break;
					case igCommandId.kSetVertexShaderTextureEnabledConstant:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer * 2);
						//getVertexShaderTexture(secondValue);
						//Set constant at firstValue to true if above returns non-null
						break;
					case igCommandId.kSetPixelShaderTextureSizeConstant:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer * 2);
						//getPixelShaderTexture(secondValue);
						//Extra stuff
						break;
					case igCommandId.kSetVertexShaderTextureSizeConstant:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer * 2);
						//getVertexShaderTexture(secondValue);
						//Extra stuff
						break;
					case igCommandId.kClearRenderTarget:
						sh.Align(4);
						sh.Seek(0x1C, SeekOrigin.Current);
						//Call Clear with args
						break;
					case igCommandId.kDraw:
						//Call Draw
						break;
					case igCommandId.kDrawPrimitives:
						sh.Align(4);
						sh.Seek(0x0C, SeekOrigin.Current);
						//Set Primitive type and then draw
						break;
					case igCommandId.kFlush:
						//Call flush
						break;
					case igCommandId.kResetState:
						//Call resetAllState
						break;
					case igCommandId.kDecodeMemoryCommandStream:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer, SeekOrigin.Current);
						//Read pointer and decode it. Above, you'll see we skip over the pointer 
						break;
					case igCommandId.kCopyTexture:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer * 6, SeekOrigin.Current);
						//Call copy texture, using the first 3 pointers
						break;
					case igCommandId.kUpdateTexture:
						sh.Align(sizeOfPointer);
						//ulong, uint, 4 bytes padding?, uint, uint, uint
						sh.Seek(sizeOfPointer + 0x18, SeekOrigin.Current);
						break;
					case igCommandId.kExecuteCallback:
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer * 3, SeekOrigin.Current);
						break;
					case igCommandId.kSetCameraMatrices:
						sh.Align(16);
						sh.Seek(0xD0, SeekOrigin.Current);	//Please don't break;
						break;
					case igCommandId.kComputeandSetInstanceMatrices:
						//Appears to be 2 pointers to some matrices, followed by a ushort 
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer * 2 + 2, SeekOrigin.Current);
						sh.Align(sizeOfPointer);
						break;
					case igCommandId.kComputeAndSetInstanceConstraints:
						//Literally 2 bytes
						sh.Seek(2, SeekOrigin.Current);
						break;
					case igCommandId.kSetCommonRenderState:
						//Literally 2 bytes
						sh.Seek(2, SeekOrigin.Current);
						break;
					case igCommandId.kSetDitherState:
						//bool, float = 8 bytes cos alignment
						sh.Seek(8, SeekOrigin.Current);
						break;
					case igCommandId.kBeginNamedEvent:
						//char*
						sh.Seek(sizeOfPointer, SeekOrigin.Current);
						break;
					case igCommandId.kEndNamedEvent:
						//short
						sh.Seek(4, SeekOrigin.Current);
						break;
					case igCommandId.kIssueBufferedGpuTimestamp:
						//either long* or ulong*
						sh.Align(sizeOfPointer);
						sh.Seek(sizeOfPointer, SeekOrigin.Current);
						break;
					default:
						break;
				}
			}
		}
	}
}