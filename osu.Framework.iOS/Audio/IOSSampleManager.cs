﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Concurrent;
using System.Threading.Tasks;
using osu.Framework.Audio.Sample;
using osu.Framework.IO.Stores;

namespace osu.Framework.iOS.Audio
{
    public class IOSSampleManager : SampleManager
    {
        public IOSSampleManager(IResourceStore<byte[]> store) : base(store)
        {
        }

        public override Sample CreateSample(byte[] data, ConcurrentQueue<Task> customPendingActions, int concurrency) => new IOSSampleBass(data, customPendingActions, concurrency);
    }
}
