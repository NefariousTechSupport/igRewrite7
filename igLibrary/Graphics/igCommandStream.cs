namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x20, 0x40)]
	public class igCommandStream : igObject
	{
		[igField(typeof(igRawRefMetaField), 0x09, 0x00, 0x08, 0x10, "_writeHead")]
		public ulong _writeHead;
		[igField(typeof(igRawRefMetaField), 0x09, 0x01, 0x0C, 0x18, "_writeChunkBegin")]
		public ulong _writeChunkBegin;
		[igField(typeof(igRawRefMetaField), 0x09, 0x02, 0x10, 0x20, "_writeChunkEnd")]
		public ulong _writeChunkEnd;
		[igField(typeof(igRawRefMetaField), 0x09, 0x03, 0x14, 0x28, "_readHead")]
		public ulong _readHead;
		[igField(typeof(igRawRefMetaField), 0x09, 0x04, 0x18, 0x30, "_readChunkBegin")]
		public ulong _readChunkBegin;
		[igField(typeof(igRawRefMetaField), 0x09, 0x05, 0x1C, 0x38, "_readChunkEnd")]
		public ulong _readChunkEnd;

		public List<igCommand> _commands = new List<igCommand>();
		private igIGZ? _igz;

		public struct igCommand
		{
			public igCommandId _id;
			public object? _parameters;
		}

		public override void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);

			_igz = igz;
		}

		public void Decode()
		{
			if(_igz == null) throw new NullReferenceException("IGZ should not be null");

			StreamHelper sh = _igz._stream;

			_commands.Clear();

			sh.Seek(_readChunkBegin);

			bool is64Bit = igCore.IsPlatform64Bit(_igz._platform);
			uint pointerSize = is64Bit ? 8u : 4u;
			uint poolOffset = _igz._loadedPointers.Last(x => x != 0 && x <= _readChunkBegin);

			while(true)
			{
				if((_readChunkEnd - sh.Tell()) < 4) break;

				sh.Align(poolOffset, 4);

				igCommand command = new igCommand();
				command._id = (igCommandId)sh.ReadUInt32();
				
				switch(command._id)
				{
					case igCommandId.kSetPrimitiveType:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.SetPrimitiveTypeParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetVertexBuffer:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetVertexBufferParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetIndexBuffer:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetIndexBufferParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetVertexShader:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetVertexShaderParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetVertexShaderVariant:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetVertexShaderVariantParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetVertexShaderTexture:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetVertexShaderTextureParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetVertexShaderSampler:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetVertexShaderSamplerParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetViewport:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetViewportParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetScissor:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.SetScissorParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetScissorEnabled:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.SetScissorEnabledParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetRasterizeStateBundle:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetRasterizeStateBundleParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetPixelShader:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetPixelShaderParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetPixelShaderVariant:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetPixelShaderVariantParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetPixelShaderTexture:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetPixelShaderTextureParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetPixelShaderSampler:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetPixelShaderSamplerParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetAlphaTestStateBundle:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetAlphaTestStateBundleParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetBlendStateBundle:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetBlendStateBundleParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetDepthStateBundle:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetDepthStateBundleParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetStencilStateBundle:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetStencilStateBundleParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetStencilRef:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.SetStencilRefParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetRenderTargets:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetRenderTargetsParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetRenderTargetMask:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetRenderTargetMaskParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kXenonSetHiStencil:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.XenonSetHiStencilParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kXenonFlushHiZStencil:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.XenonSetFlushHiZStencilParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kXenonSetGprCounts:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.XenonGprCountsParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kPS3DrawEdgeGeometry:
						break;
					case igCommandId.kPS3SetSCull:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.PS3SetSCullParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantBool:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetConstantBoolParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantInt:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetConstantIntParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantFloat:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetConstantFloatParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantVec4f:
						sh.Align(poolOffset, 0x10);
						command._parameters = igGraphics.SetConstantVec4fParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantMatrix44f:
						sh.Align(poolOffset, 0x10);
						command._parameters = igGraphics.SetConstantMatrix44fParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantArrayInt:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetConstantArrayIntParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantArrayFloat:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetConstantArrayFloatParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantArrayVec4f:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetConstantArrayVec4fParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetConstantArrayMatrix44f:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetConstantMatrix44fParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kApplyConstantBundle:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.ApplyConstantBundleParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kApplyConstantValueList:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.ApplyConstantValueListParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetPixelShaderTextureEnabledConstant:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetPixelShaderTextureEnabledConstantParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetVertexShaderTextureEnabledConstant:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetVertexShaderTextureEnabledConstantParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetPixelShaderTextureSizeConstant:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetPixelShaderTextureSizeConstantParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetVertexShaderTextureSizeConstant:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetVertexShaderTextureSizeConstantParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kClearRenderTarget:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.ClearRenderTargetParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kDraw:
						break;
					case igCommandId.kDrawPrimitives:
						sh.Align(poolOffset, 4);
						command._parameters = igGraphics.DrawPrimitivesParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kFlush:
						break;
					case igCommandId.kResetState:
						break;
					case igCommandId.kDecodeMemoryCommandStream:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.DecodeMemoryCommandStreamParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kCopyTexture:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.CopyTextureParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kUpdateTexture:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.UpdateTextureParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kExecuteCallback:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.ExecuteCallbackParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetCameraMatrices:
						sh.Align(poolOffset, 0x10);
						command._parameters = igGraphics.SetCameraMatricesParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kComputeAndSetInstanceMatrices:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.ComputeAndSetInstanceMatricesParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kComputeAndSetInstanceConstants:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.ComputeAndSetInstanceConstantsParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetCommonRenderState:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetCommonRenderStateParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kSetDitherState:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.SetDitherStateParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kBeginNamedEvent:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.BeginNamedEventParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kEndNamedEvent:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.EndNamedEventParamsField.ReadRawMemory(_igz, is64Bit);
						break;
					case igCommandId.kIssueBufferedGpuTimestamp:
						sh.Align(poolOffset, pointerSize);
						command._parameters = igGraphics.IssueBufferedGpuTimestampParamsField.ReadRawMemory(_igz, is64Bit);
						break;
				}

				_commands.Add(command);
			}			
		}
	}
}