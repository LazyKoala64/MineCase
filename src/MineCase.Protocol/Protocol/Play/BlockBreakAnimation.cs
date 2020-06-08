﻿using System.IO;
using MineCase.Serialization;

namespace MineCase.Protocol.Play
{
    [Packet(0x09)]
    public sealed class BlockBreakAnimation : ISerializablePacket
    {
        [SerializeAs(DataType.VarInt)]
        public uint EntityID;

        [SerializeAs(DataType.Position)]
        public Position BlockPosition;

        [SerializeAs(DataType.Byte)]
        public byte DestoryStage;

        public void Serialize(BinaryWriter bw)
        {
            bw.WriteAsVarInt(EntityID, out _);
            bw.WriteAsPosition(BlockPosition);
            bw.WriteAsByte(DestoryStage);
        }
    }
}
