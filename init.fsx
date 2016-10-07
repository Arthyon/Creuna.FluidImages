// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r @"packages/build/FAKE/tools/FakeLib.dll"
open Fake
open Fake.Git
open Fake.AssemblyInfoFile
open Fake.ReleaseNotesHelper
open Fake.UserInputHelper
open System
open System.IO
#if MONO
#else
#load "packages/build/SourceLink.Fake/tools/Fake.fsx"
open SourceLink
#endif

let project = "Creuna.FluidImages"
let summary = "An EPiServer plugin enabling editors to set the focus point of an image"
let release = LoadReleaseNotes "RELEASE_NOTES.md"

Target "AssemblyInfo" (fun _ ->
    let getAssemblyInfoAttributes projectName =
        [ Attribute.Title (projectName)
          Attribute.Product project
          Attribute.Description summary
          Attribute.Version release.AssemblyVersion
          Attribute.FileVersion release.AssemblyVersion ]

    let getProjectDetails projectPath =
        let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
        ( projectPath,
          projectName,
          System.IO.Path.GetDirectoryName(projectPath),
          (getAssemblyInfoAttributes projectName)
        )

    !! "src/Creuna.FluidImages/Creuna.FluidImages.csproj"
    |> Seq.map getProjectDetails
    |> Seq.iter (fun (projFileName, projectName, folderName, attributes) ->
        CreateCSharpAssemblyInfo ((folderName </> "Properties") </> "AssemblyInfo.cs") attributes
    )
)


Target "Build" (fun _ ->
    !! "src/Creuna.FluidImages/Creuna.FluidImages.csproj"
#if MONO
    |> MSBuildReleaseExt "" [ ("DefineConstants","MONO") ] "Build"
#else
    |> MSBuildRelease "" "Build"
#endif
    |> ignore
)


Target "CopyBinaries" (fun _ ->
    !! "src/Creuna.FluidImages/Creuna.FluidImages.csproj"
    |>  Seq.map (fun f -> ((System.IO.Path.GetDirectoryName f) </> "bin/Release", "bin" </> (System.IO.Path.GetFileNameWithoutExtension f)))
    |>  Seq.iter (fun (fromDir, toDir) -> CopyDir toDir fromDir (fun _ -> true))
)


Target "NuGet" (fun _ ->
    Paket.Pack(fun p ->
        { p with
            OutputPath = "bin"
            Version = release.NugetVersion
            ReleaseNotes = toLines release.Notes})
)

Target "Initialize" DoNothing

"AssemblyInfo"
 ==> "Build"
 ==> "CopyBinaries"
 ==> "NuGet"
 ==> "Initialize"

RunTargetOrDefault "Initialize"