# EntLibLoggingWrapper

This sample contains logging wrappers for Enterprise Library Logging Application Block 6.0.
I think the app.config is also helpful to learn how to configure EL Logging.

You can find all of the logging wrappers under sub-folder `Logging`.

URL of the source code: <https://github.com/huanlin/Examples/DotNet/Logging/EntLibLoggingWrapper>

## Run This Demo

After you run this demo applciation, you will see new log messages written to files in the application's `Logs` sub-folder.

## EntLibLogFactory

Class EntLibLogFactory has two constructors. If you use default constructor, you must define a special source named "notProcessed" in your configuration file. See example below:

        <specialSources>
          <allEvents switchValue="All" name="All Events" />
          <notProcessed switchValue="All" name="Unprocessed Category">
            <listeners>
              <add name="RollingFileLogListener" />
            </listeners>
          </notProcessed>
        </specialSources>

This is because EntLibLogFactory uses caller's type name as the default category name.
If you don't like it, just use another constructor to create the instance of EntLibLogFactory. In which you can pass a category name to the constructor, and define that category in your configuration file. 
For example, somewhere in your application's initialization code:

    static logFactory = new EntLibLogFactory("BusinessLogic");

Then, in your application configuration file:

    <categorySources>
      <add switchValue="All" name="BusinessLogic">
        <listeners>
          <add name="RollingFileLogListener" />
        </listeners>
      </add>
    </categorySources>


