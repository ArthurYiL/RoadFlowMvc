﻿// Decompiled with JetBrains decompiler
// Type: UEConfigHandler
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System.Web;

public class UEConfigHandler : UEHandler
{
  public UEConfigHandler(HttpContext context)
    : base(context)
  {
  }

  public override void Process()
  {
    this.WriteJson((object) UEConfig.Items);
  }
}
