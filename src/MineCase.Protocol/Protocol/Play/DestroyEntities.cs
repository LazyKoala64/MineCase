﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MineCase.Serialization;

namespace MineCase.Protocol.Play
{
    [Packet(0x38)]
    public sealed class DestroyEntities : ISerializablePacket
    {
        [SerializeAs(DataType.VarInt)]
        public uint Count;

        [SerializeAs(DataType.Array)]
        public uint[] EntityIds;

        public void Serialize(BinaryWriter bw)
        {
            bw.WriteAsVarInt(Count, out _);
            foreach (var eid in EntityIds)
                bw.WriteAsVarInt(eid, out _);
        }
    }
}
