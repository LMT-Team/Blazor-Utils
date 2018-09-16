function LMTDevBoot() {
  if (window.Dev == null) {
    window.Dev = {};

    window.Dev.SetObjectPropertyValue = (objectName, propertyName, value) => {

      const assemblyName = "BlazorUtils.Dev";
      const namespace = "BlazorUtils.Dev";
      const typeName = "Dev";
      const methodName = "Set";

      const method = Blazor.platform.findMethod(
        assemblyName,
        namespace,
        typeName,
        methodName
      );

      let csObjectName = Blazor.platform.toDotNetString(objectName);
      let csPropertyName = Blazor.platform.toDotNetString(propertyName);
      let csValue = Blazor.platform.toDotNetString(value.toString());

      Blazor.platform.toJavaScriptString(
        Blazor.platform.callMethod(method, null, [
          csObjectName,
          csPropertyName,
          csValue
        ])
      );
    };
  }
}

LMTDevBoot();
