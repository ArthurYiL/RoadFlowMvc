﻿// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IProgramBuilder
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IProgramBuilder
  {
    int Add(ProgramBuilder model);

    int Update(ProgramBuilder model);

    List<ProgramBuilder> GetAll();

    ProgramBuilder Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    List<ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "");
  }
}
