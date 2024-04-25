// ts2fable 0.7.1
module rec Three

open System
open Fable.Core
open Fable.Core.JS
open Browser.Types

type Array<'T> = System.Collections.Generic.IList<'T>
type ArrayLike<'T> = System.Collections.Generic.IList<'T>
type Iterable<'T> = System.Collections.Generic.IEnumerable<'T>
type Error = System.Exception
type Function = System.Action
type RegExp = System.Text.RegularExpressions.Regex


[<AllowNullLiteral>]
type IExports =
    abstract Scene: SceneStatic
    abstract PerspectiveCamera: PerspectiveCameraStatic
    abstract WebGLRenderer: WebGLRendererStatic
    abstract Color: ColorStatic
    abstract AxesHelper: AxesHelperStatic
    abstract PlaneGeometry: PlaneGeometryStatic
    abstract MeshLambertMaterial: MeshLambertMaterialStatic
    abstract SphereGeometry: SphereGeometryStatic
    abstract EdgesGeometry: EdgesGeometryStatic
    abstract WireframeGeometry: WireframeGeometryStatic
    abstract SpotLight: SpotLightStatic
    abstract DirectionalLight: DirectionalLightStatic
    abstract AmbientLight: AmbientLightStatic
    abstract Vector2: Vector2Static
    abstract Vector3: Vector3Static
    abstract Mesh: MeshStatic
    abstract BoxGeometry: BoxGeometryStatic
    abstract Clock: ClockStatic
    abstract MeshBasicMaterial: MeshBasicMaterialStatic
    abstract MeshToonMaterial: MeshToonMaterialStatic
    abstract LineBasicMaterial: LineBasicMaterialStatic
    abstract LineSegments: LineSegmentsStatic
    abstract OrthographicCamera: OrthographicCameraStatic
    abstract Box3: Box3Static
    abstract Plane: PlaneStatic

[<Import("*", "three")>]
let exports: IExports = jsNative


// type AnimationBlendMode = obj
// type AnimationActionLoopStyles = obj

[<AllowNullLiteral>]
type AnimationAction =
    abstract blendMode: AnimationBlendMode with get, set
    abstract loop: AnimationActionLoopStyles with get, set
    abstract time: float with get, set
    abstract timeScale: float with get, set
    abstract weight: float with get, set
    abstract repetitions: float with get, set
    abstract paused: bool with get, set
    abstract enabled: bool with get, set
    abstract clampWhenFinished: bool with get, set
    abstract zeroSlopeAtStart: bool with get, set
    abstract zeroSlopeAtEnd: bool with get, set
    abstract play: unit -> AnimationAction
    abstract stop: unit -> AnimationAction
    abstract reset: unit -> AnimationAction
    abstract isRunning: unit -> bool
    abstract isScheduled: unit -> bool
    abstract startAt: time:float -> AnimationAction
    abstract setLoop: mode:AnimationActionLoopStyles * repetitions:float -> AnimationAction
    abstract setEffectiveWeight: weight:float -> AnimationAction
    abstract getEffectiveWeight: unit -> float
    abstract fadeIn: duration:float -> AnimationAction
    abstract fadeOut: duration:float -> AnimationAction
    abstract crossFadeFrom: fadeOutAction:AnimationAction * duration:float * warp:bool -> AnimationAction
    abstract crossFadeTo: fadeInAction:AnimationAction * duration:float * warp:bool -> AnimationAction
    abstract stopFading: unit -> AnimationAction
    abstract setEffectiveTimeScale: timeScale:float -> AnimationAction
    abstract getEffectiveTimeScale: unit -> float
    abstract setDuration: duration:float -> AnimationAction
    abstract syncWith: action:AnimationAction -> AnimationAction
    abstract halt: duration:float -> AnimationAction
    abstract warp: statTimeScale:float * endTimeScale:float * duration:float -> AnimationAction
    abstract stopWarping: unit -> AnimationAction
    abstract getMixer: unit -> AnimationMixer
    abstract getClip: unit -> AnimationClip
    abstract getRoot: unit -> Object3D

[<AllowNullLiteral>]
type AnimationActionStatic =
    [<Emit "new $0($1...)">]
    abstract Create: mixer:AnimationMixer
                     * clip:AnimationClip
                     * ?localRoot:Object3D
                     * ?blendMode:AnimationBlendMode
                     -> AnimationAction





[<AllowNullLiteral>]
type AnimationClip =
    abstract name: string with get, set
    abstract tracks: ResizeArray<KeyframeTrack> with get, set
    abstract blendMode: AnimationBlendMode with get, set
    abstract duration: float with get, set
    abstract uuid: string with get, set
    abstract results: ResizeArray<obj> with get, set
    abstract resetDuration: unit -> AnimationClip
    abstract trim: unit -> AnimationClip
    abstract validate: unit -> bool
    abstract optimize: unit -> AnimationClip
    abstract clone: unit -> AnimationClip

[<AllowNullLiteral>]
type AnimationClipStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?name:string
                     * ?duration:float
                     * ?tracks:ResizeArray<KeyframeTrack>
                     * ?blendMode:AnimationBlendMode
                     -> AnimationClip

    abstract CreateFromMorphTargetSequence: name:string
                                            * morphTargetSequence:ResizeArray<MorphTarget>
                                            * fps:float
                                            * noLoop:bool
                                            -> AnimationClip

    abstract findByName: clipArray:ResizeArray<AnimationClip> * name:string -> AnimationClip

    abstract CreateClipsFromMorphTargetSequences: morphTargets:ResizeArray<MorphTarget>
                                                  * fps:float
                                                  * noLoop:bool
                                                  -> ResizeArray<AnimationClip>

    abstract parse: json:obj -> AnimationClip
    abstract parseAnimation: animation:obj * bones:ResizeArray<Bone> -> AnimationClip
    abstract toJSON: unit -> obj








[<AllowNullLiteral>]
type AnimationMixer =
    inherit EventDispatcher
    abstract time: float with get, set
    abstract timeScale: float with get, set

    abstract clipAction: clip:AnimationClip
                         * ?root:U2<Object3D, AnimationObjectGroup>
                         * ?blendMode:AnimationBlendMode
                         -> AnimationAction

    abstract existingAction: clip:AnimationClip * ?root:U2<Object3D, AnimationObjectGroup> -> AnimationAction option
    abstract stopAllAction: unit -> AnimationMixer
    abstract update: deltaTime:float -> AnimationMixer
    abstract setTime: timeInSeconds:float -> AnimationMixer
    abstract getRoot: unit -> U2<Object3D, AnimationObjectGroup>
    abstract uncacheClip: clip:AnimationClip -> unit
    abstract uncacheRoot: root:U2<Object3D, AnimationObjectGroup> -> unit
    abstract uncacheAction: clip:AnimationClip * ?root:U2<Object3D, AnimationObjectGroup> -> unit

[<AllowNullLiteral>]
type AnimationMixerStatic =
    [<Emit "new $0($1...)">]
    abstract Create: root:U2<Object3D, AnimationObjectGroup> -> AnimationMixer


[<AllowNullLiteral>]
type AnimationObjectGroup =
    abstract uuid: string with get, set
    abstract stats: AnimationObjectGroupStats with get, set
    abstract isAnimationObjectGroup: obj
    abstract add: [<ParamArray>] args:ResizeArray<obj> -> unit
    abstract remove: [<ParamArray>] args:ResizeArray<obj> -> unit
    abstract uncache: [<ParamArray>] args:ResizeArray<obj> -> unit

[<AllowNullLiteral>]
type AnimationObjectGroupStatic =
    [<Emit "new $0($1...)">]
    abstract Create: [<ParamArray>] args:ResizeArray<obj> -> AnimationObjectGroup

[<AllowNullLiteral>]
type AnimationObjectGroupStatsObjects =
    abstract total: float with get, set
    abstract inUse: float with get, set

[<AllowNullLiteral>]
type AnimationObjectGroupStats =
    abstract bindingsPerObject: float with get, set
    abstract objects: AnimationObjectGroupStatsObjects with get, set

[<Import("AnimationUtils", "three")>]
let animationUtils: AnimationUtils.IExports = jsNative

module AnimationUtils =

    [<AllowNullLiteral>]
    type IExports =
        abstract arraySlice: array:obj * from:float * ``to``:float -> obj
        abstract convertArray: array:obj * ``type``:obj * forceClone:bool -> obj
        abstract isTypedArray: object:obj -> bool
        abstract getKeyFrameOrder: times:ResizeArray<float> -> ResizeArray<float>

        abstract sortedArray: values:ResizeArray<obj>
                              * stride:float
                              * order:ResizeArray<float>
                              -> ResizeArray<obj>

        abstract flattenJSON: jsonKeys:ResizeArray<string>
                              * times:ResizeArray<obj>
                              * values:ResizeArray<obj>
                              * valuePropertyName:string
                              -> unit

        abstract subclip: sourceClip:AnimationClip
                          * name:string
                          * startFrame:float
                          * endFrame:float
                          * ?fps:float
                          -> AnimationClip

        abstract makeClipAdditive: targetClip:AnimationClip
                                   * ?referenceFrame:float
                                   * ?referenceClip:AnimationClip
                                   * ?fps:float
                                   -> AnimationClip





type DiscreteInterpolant = obj
type LinearInterpolant = obj
type CubicInterpolant = obj

[<AllowNullLiteral>]
type KeyframeTrack =
    abstract name: string with get, set
    abstract times: Float32Array with get, set
    abstract values: Float32Array with get, set
    abstract ValueTypeName: string with get, set
    abstract TimeBufferType: Float32Array with get, set
    abstract ValueBufferType: Float32Array with get, set
    abstract DefaultInterpolation: InterpolationModes with get, set
    abstract InterpolantFactoryMethodDiscrete: result:obj -> DiscreteInterpolant
    abstract InterpolantFactoryMethodLinear: result:obj -> LinearInterpolant
    abstract InterpolantFactoryMethodSmooth: result:obj -> CubicInterpolant
    abstract setInterpolation: interpolation:InterpolationModes -> KeyframeTrack
    abstract getInterpolation: unit -> InterpolationModes
    abstract getValueSize: unit -> float
    abstract shift: timeOffset:float -> KeyframeTrack
    abstract scale: timeScale:float -> KeyframeTrack
    abstract trim: startTime:float * endTime:float -> KeyframeTrack
    abstract validate: unit -> bool
    abstract optimize: unit -> KeyframeTrack
    abstract clone: unit -> KeyframeTrack

[<AllowNullLiteral>]
type KeyframeTrackStatic =
    [<Emit "new $0($1...)">]
    abstract Create: name:string
                     * times:ResizeArray<obj>
                     * values:ResizeArray<obj>
                     * ?interpolation:InterpolationModes
                     -> KeyframeTrack

    abstract toJSON: track:KeyframeTrack -> obj

[<Import("PropertyBinding", "three")>]
let propertyBinding: PropertyBinding.IExports = jsNative


[<AllowNullLiteral>]
type ParseTrackNameResults =
    abstract nodeName: string with get, set
    abstract objectName: string with get, set
    abstract objectIndex: string with get, set
    abstract propertyName: string with get, set
    abstract propertyIndex: string with get, set

[<AllowNullLiteral>]
type PropertyBinding =
    abstract path: string with get, set
    abstract parsedPath: obj with get, set
    abstract node: obj with get, set
    abstract rootNode: obj with get, set
    abstract getValue: targetArray:obj * offset:float -> obj
    abstract setValue: sourceArray:obj * offset:float -> unit
    abstract bind: unit -> unit
    abstract unbind: unit -> unit
    abstract BindingType: PropertyBindingBindingType with get, set
    abstract Versioning: PropertyBindingVersioning with get, set
    abstract GetterByBindingType: ResizeArray<Function> with get, set
    abstract SetterByBindingTypeAndVersioning: Array<ResizeArray<Function>> with get, set

[<AllowNullLiteral>]
type PropertyBindingStatic =
    [<Emit "new $0($1...)">]
    abstract Create: rootNode:obj * path:string * ?parsedPath:obj -> PropertyBinding

    abstract create: root:obj
                     * path:obj
                     * ?parsedPath:obj
                     -> U2<PropertyBinding, PropertyBinding.Composite>

    abstract sanitizeNodeName: name:string -> string
    abstract parseTrackName: trackName:string -> ParseTrackNameResults
    abstract findNode: root:obj * nodeName:string -> obj

module PropertyBinding =

    [<AllowNullLiteral>]
    type IExports =
        abstract Composite: CompositeStatic

    [<AllowNullLiteral>]
    type Composite =
        abstract getValue: array:obj * offset:float -> obj
        abstract setValue: array:obj * offset:float -> unit
        abstract bind: unit -> unit
        abstract unbind: unit -> unit

    [<AllowNullLiteral>]
    type CompositeStatic =
        [<Emit "new $0($1...)">]
        abstract Create: targetGroup:obj * path:obj * ?parsedPath:obj -> Composite

[<AllowNullLiteral>]
type PropertyBindingBindingType =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: bindingType:string -> float with get, set

[<AllowNullLiteral>]
type PropertyBindingVersioning =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: versioning:string -> float with get, set


[<AllowNullLiteral>]
type PropertyMixer =
    abstract binding: obj with get, set
    abstract valueSize: float with get, set
    abstract buffer: obj with get, set
    abstract cumulativeWeight: float with get, set
    abstract cumulativeWeightAdditive: float with get, set
    abstract useCount: float with get, set
    abstract referenceCount: float with get, set
    abstract accumulate: accuIndex:float * weight:float -> unit
    abstract accumulateAdditive: weight:float -> unit
    abstract apply: accuIndex:float -> unit
    abstract saveOriginalState: unit -> unit
    abstract restoreOriginalState: unit -> unit

[<AllowNullLiteral>]
type PropertyMixerStatic =
    [<Emit "new $0($1...)">]
    abstract Create: binding:obj * typeName:string * valueSize:float -> PropertyMixer



type AudioBuffer = obj
type AudioContext = obj
type GainNode = obj
type AudioBufferSourceNode = obj
type MediaStream = obj
type AudioNode = obj
type Audio = Audio<obj>

[<AllowNullLiteral>]
type Audio<'NodeType> =
    inherit Object3D
    abstract ``type``: string with get, set
    abstract listener: AudioListener with get, set
    abstract context: AudioContext with get, set
    abstract gain: GainNode with get, set
    abstract autoplay: bool with get, set
    abstract buffer: AudioBuffer with get, set
    abstract detune: float with get, set
    abstract loop: bool with get, set
    abstract loopStart: float with get, set
    abstract loopEnd: float with get, set
    abstract offset: float with get, set
    abstract duration: float with get, set
    abstract playbackRate: float with get, set
    abstract isPlaying: bool with get, set
    abstract hasPlaybackControl: bool with get, set
    abstract sourceType: string with get, set
    abstract source: AudioBufferSourceNode with get, set
    abstract filters: ResizeArray<obj> with get, set
    abstract getOutput: unit -> 'NodeType
    abstract setNodeSource: audioNode:AudioBufferSourceNode -> Audio<'NodeType>
    abstract setMediaElementSource: mediaElement:HTMLMediaElement -> Audio<'NodeType>
    abstract setMediaStreamSource: mediaStream:MediaStream -> Audio<'NodeType>
    abstract setBuffer: audioBuffer:AudioBuffer -> Audio<'NodeType>
    abstract play: ?delay:float -> Audio<'NodeType>
    abstract onEnded: unit -> unit
    abstract pause: unit -> Audio<'NodeType>
    abstract stop: unit -> Audio<'NodeType>
    abstract connect: unit -> Audio<'NodeType>
    abstract disconnect: unit -> Audio<'NodeType>
    abstract setDetune: value:float -> Audio<'NodeType>
    abstract getDetune: unit -> float
    abstract getFilters: unit -> ResizeArray<obj>
    abstract setFilters: value:ResizeArray<obj> -> Audio<'NodeType>
    abstract getFilter: unit -> obj
    abstract setFilter: filter:obj -> Audio<'NodeType>
    abstract setPlaybackRate: value:float -> Audio<'NodeType>
    abstract getPlaybackRate: unit -> float
    abstract getLoop: unit -> bool
    abstract setLoop: value:bool -> Audio<'NodeType>
    abstract setLoopStart: value:float -> Audio<'NodeType>
    abstract setLoopEnd: value:float -> Audio<'NodeType>
    abstract getVolume: unit -> float
    abstract setVolume: value:float -> Audio<'NodeType>
    abstract load: file:string -> Audio

[<AllowNullLiteral>]
type AudioStatic =
    [<Emit "new $0($1...)">]
    abstract Create: listener:AudioListener -> Audio<'NodeType>

type AnalyserNode = obj

[<AllowNullLiteral>]
type AudioAnalyser =
    abstract analyser: AnalyserNode with get, set
    abstract data: Uint8Array with get, set
    abstract getFrequencyData: unit -> Uint8Array
    abstract getAverageFrequency: unit -> float
    abstract getData: file:obj -> obj

[<AllowNullLiteral>]
type AudioAnalyserStatic =
    [<Emit "new $0($1...)">]
    abstract Create: audio:Audio<AudioNode> * fftSize:float -> AudioAnalyser

[<Import("AudioContext", "three")>]
let AudioContext: AudioContext = jsNative




[<AllowNullLiteral>]
type AudioListener =
    inherit Object3D
    abstract ``type``: string with get, set
    abstract context: AudioContext with get, set
    abstract gain: GainNode with get, set
    abstract filter: obj with get, set
    abstract timeDelta: float with get, set
    abstract getInput: unit -> GainNode
    abstract removeFilter: unit -> AudioListener
    abstract setFilter: value:obj -> AudioListener
    abstract getFilter: unit -> obj
    abstract setMasterVolume: value:float -> AudioListener
    abstract getMasterVolume: unit -> float
    /// Updates global transform of the object and its children.
    abstract updateMatrixWorld: ?force:bool -> unit

[<AllowNullLiteral>]
type AudioListenerStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> AudioListener


type DistanceModelType = obj
type PannerNode = obj

[<AllowNullLiteral>]
type PositionalAudio =
    inherit Audio<PannerNode>
    abstract panner: PannerNode with get, set
    abstract getOutput: unit -> PannerNode
    abstract setRefDistance: value:float -> PositionalAudio
    abstract getRefDistance: unit -> float
    abstract setRolloffFactor: value:float -> PositionalAudio
    abstract getRolloffFactor: unit -> float
    abstract setDistanceModel: value:DistanceModelType -> PositionalAudio
    abstract getDistanceModel: unit -> DistanceModelType
    abstract setMaxDistance: value:float -> PositionalAudio
    abstract getMaxDistance: unit -> float
    abstract setDirectionalCone: coneInnerAngle:float * coneOuterAngle:float * coneOuterGain:float -> PositionalAudio
    /// Updates global transform of the object and its children.
    abstract updateMatrixWorld: ?force:bool -> unit

[<AllowNullLiteral>]
type PositionalAudioStatic =
    [<Emit "new $0($1...)">]
    abstract Create: listener:AudioListener -> PositionalAudio



[<AllowNullLiteral>]
type ArrayCamera =
    inherit PerspectiveCamera
    abstract cameras: ResizeArray<PerspectiveCamera> with get, set
    abstract isArrayCamera: obj

[<AllowNullLiteral>]
type ArrayCameraStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?cameras:ResizeArray<PerspectiveCamera> -> ArrayCamera





/// Abstract base class for cameras. This class should always be inherited when you build a new camera.
[<AllowNullLiteral>]
type Camera =
    inherit Object3D
    /// This is the inverse of matrixWorld. MatrixWorld contains the Matrix which has the world transform of the Camera.
    abstract matrixWorldInverse: Matrix4 with get, set
    /// This is the matrix which contains the projection.
    abstract projectionMatrix: Matrix4 with get, set
    /// This is the inverse of projectionMatrix.
    abstract projectionMatrixInverse: Matrix4 with get, set
    abstract isCamera: obj
    abstract getWorldDirection: target:Vector3 -> Vector3
    /// Updates global transform of the object and its children.
    abstract updateMatrixWorld: ?force:bool -> unit

/// Abstract base class for cameras. This class should always be inherited when you build a new camera.
[<AllowNullLiteral>]
type CameraStatic =
    /// This constructor sets following properties to the correct type: matrixWorldInverse, projectionMatrix and projectionMatrixInverse.
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Camera






[<AllowNullLiteral>]
type CubeCamera =
    inherit Object3D
    abstract ``type``: string with get, set
    abstract renderTarget: WebGLCubeRenderTarget with get, set
    abstract update: renderer:WebGLRenderer * scene:Scene -> unit
    abstract clear: renderer:WebGLRenderer * color:bool * depth:bool * stencil:bool -> unit

[<AllowNullLiteral>]
type CubeCameraStatic =
    [<Emit "new $0($1...)">]
    abstract Create: near:float * far:float * renderTarget:WebGLCubeRenderTarget -> CubeCamera



/// Camera with orthographic projection
[<AllowNullLiteral>]
type OrthographicCamera =
    inherit Camera
    abstract ``type``: string with get, set
    abstract isOrthographicCamera: obj
    abstract zoom: float with get, set
    abstract view: OrthographicCameraView with get, set
    /// Camera frustum left plane.
    abstract left: float with get, set
    /// Camera frustum right plane.
    abstract right: float with get, set
    /// Camera frustum top plane.
    abstract top: float with get, set
    /// Camera frustum bottom plane.
    abstract bottom: float with get, set
    /// Camera frustum near plane.
    abstract near: float with get, set
    /// Camera frustum far plane.
    abstract far: float with get, set
    /// Updates the camera projection matrix. Must be called after change of parameters.
    abstract updateProjectionMatrix: unit -> unit

    abstract setViewOffset: fullWidth:float
                            * fullHeight:float
                            * offsetX:float
                            * offsetY:float
                            * width:float
                            * height:float
                            -> unit

    abstract clearViewOffset: unit -> unit
    abstract toJSON: ?meta:obj -> obj

/// Camera with orthographic projection
[<AllowNullLiteral>]
type OrthographicCameraStatic =
    /// <param name="left">Camera frustum left plane.</param>
    /// <param name="right">Camera frustum right plane.</param>
    /// <param name="top">Camera frustum top plane.</param>
    /// <param name="bottom">Camera frustum bottom plane.</param>
    /// <param name="near">Camera frustum near plane.</param>
    /// <param name="far">Camera frustum far plane.</param>
    [<Emit "new $0($1...)">]
    abstract Create: left:float
                     * right:float
                     * top:float
                     * bottom:float
                     * ?near:float
                     * ?far:float
                     -> OrthographicCamera

[<AllowNullLiteral>]
type OrthographicCameraView =
    abstract enabled: bool with get, set
    abstract fullWidth: float with get, set
    abstract fullHeight: float with get, set
    abstract offsetX: float with get, set
    abstract offsetY: float with get, set
    abstract width: float with get, set
    abstract height: float with get, set



/// Camera with perspective projection.
[<AllowNullLiteral>]
type PerspectiveCamera =
    inherit Camera
    abstract ``type``: string with get, set
    abstract isPerspectiveCamera: obj
    abstract zoom: float with get, set
    /// Camera frustum vertical field of view, from bottom to top of view, in degrees.
    abstract fov: float with get, set
    /// Camera frustum aspect ratio, window width divided by window height.
    abstract aspect: float with get, set
    /// Camera frustum near plane.
    abstract near: float with get, set
    /// Camera frustum far plane.
    abstract far: float with get, set
    abstract focus: float with get, set
    abstract view: PerspectiveCameraView with get, set
    abstract filmGauge: float with get, set
    abstract filmOffset: float with get, set
    abstract setFocalLength: focalLength:float -> unit
    abstract getFocalLength: unit -> float
    abstract getEffectiveFOV: unit -> float
    abstract getFilmWidth: unit -> float
    abstract getFilmHeight: unit -> float
    /// <summary>Sets an offset in a larger frustum. This is useful for multi-window or multi-monitor/multi-machine setups.
    /// For example, if you have 3x2 monitors and each monitor is 1920x1080 and the monitors are in grid like this:
    ///
    /// 		 +---+---+---+
    /// 		 | A | B | C |
    /// 		 +---+---+---+
    /// 		 | D | E | F |
    /// 		 +---+---+---+
    ///
    /// then for each monitor you would call it like this:
    ///
    /// 		 const w = 1920;
    /// 		 const h = 1080;
    /// 		 const fullWidth = w * 3;
    /// 		 const fullHeight = h * 2;
    ///
    /// 		 // A
    /// 		 camera.setViewOffset( fullWidth, fullHeight, w * 0, h * 0, w, h );
    /// 		 // B
    /// 		 camera.setViewOffset( fullWidth, fullHeight, w * 1, h * 0, w, h );
    /// 		 // C
    /// 		 camera.setViewOffset( fullWidth, fullHeight, w * 2, h * 0, w, h );
    /// 		 // D
    /// 		 camera.setViewOffset( fullWidth, fullHeight, w * 0, h * 1, w, h );
    /// 		 // E
    /// 		 camera.setViewOffset( fullWidth, fullHeight, w * 1, h * 1, w, h );
    /// 		 // F
    /// 		 camera.setViewOffset( fullWidth, fullHeight, w * 2, h * 1, w, h ); Note there is no reason monitors have to be the same size or in a grid.</summary>
    /// <param name="fullWidth">full width of multiview setup</param>
    /// <param name="fullHeight">full height of multiview setup</param>
    /// <param name="x">horizontal offset of subcamera</param>
    /// <param name="y">vertical offset of subcamera</param>
    /// <param name="width">width of subcamera</param>
    /// <param name="height">height of subcamera</param>
    abstract setViewOffset: fullWidth:float * fullHeight:float * x:float * y:float * width:float * height:float -> unit
    abstract clearViewOffset: unit -> unit
    /// Updates the camera projection matrix. Must be called after change of parameters.
    abstract updateProjectionMatrix: unit -> unit
    abstract toJSON: ?meta:obj -> obj
    abstract setLens: focalLength:float * ?frameHeight:float -> unit

/// Camera with perspective projection.
[<AllowNullLiteral>]
type PerspectiveCameraStatic =
    /// <param name="fov">Camera frustum vertical field of view. Default value is 50.</param>
    /// <param name="aspect">Camera frustum aspect ratio. Default value is 1.</param>
    /// <param name="near">Camera frustum near plane. Default value is 0.1.</param>
    /// <param name="far">Camera frustum far plane. Default value is 2000.</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?fov:float * ?aspect:float * ?near:float * ?far:float -> PerspectiveCamera

[<AllowNullLiteral>]
type PerspectiveCameraView =
    abstract enabled: bool with get, set
    abstract fullWidth: float with get, set
    abstract fullHeight: float with get, set
    abstract offsetX: float with get, set
    abstract offsetY: float with get, set
    abstract width: float with get, set
    abstract height: float with get, set




[<AllowNullLiteral>]
type StereoCamera =
    inherit Camera
    abstract ``type``: string with get, set
    abstract aspect: float with get, set
    abstract eyeSep: float with get, set
    abstract cameraL: PerspectiveCamera with get, set
    abstract cameraR: PerspectiveCamera with get, set
    abstract update: camera:PerspectiveCamera -> unit

[<AllowNullLiteral>]
type StereoCameraStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> StereoCamera






[<AllowNullLiteral>]
type BufferAttribute =
    abstract name: string with get, set
    abstract array: ArrayLike<float> with get, set
    abstract itemSize: float with get, set
    abstract usage: Usage with get, set
    abstract updateRange: BufferAttributeUpdateRange with get, set
    abstract version: float with get, set
    abstract normalized: bool with get, set
    abstract count: float with get, set
    abstract isBufferAttribute: obj
    abstract onUploadCallback: (unit -> unit) with get, set
    abstract onUpload: callback:(unit -> unit) -> BufferAttribute
    abstract setUsage: usage:Usage -> BufferAttribute
    abstract clone: unit -> BufferAttribute
    abstract copy: source:BufferAttribute -> BufferAttribute
    abstract copyAt: index1:float * attribute:BufferAttribute * index2:float -> BufferAttribute
    abstract copyArray: array:ArrayLike<float> -> BufferAttribute
    abstract copyColorsArray: colors:ResizeArray<BufferAttributeCopyColorsArray> -> BufferAttribute
    abstract copyVector2sArray: vectors:ResizeArray<BufferAttributeCopyVector2sArray> -> BufferAttribute
    abstract copyVector3sArray: vectors:ResizeArray<BufferAttributeCopyVector3sArray> -> BufferAttribute
    abstract copyVector4sArray: vectors:ResizeArray<BufferAttributeCopyVector4sArray> -> BufferAttribute
    abstract applyMatrix3: m:Matrix3 -> BufferAttribute
    abstract applyMatrix4: m:Matrix4 -> BufferAttribute
    abstract applyNormalMatrix: m:Matrix3 -> BufferAttribute
    abstract transformDirection: m:Matrix4 -> BufferAttribute
    abstract set: value:U2<ArrayLike<float>, ArrayBufferView> * ?offset:float -> BufferAttribute
    abstract getX: index:float -> float
    abstract setX: index:float * x:float -> BufferAttribute
    abstract getY: index:float -> float
    abstract setY: index:float * y:float -> BufferAttribute
    abstract getZ: index:float -> float
    abstract setZ: index:float * z:float -> BufferAttribute
    abstract getW: index:float -> float
    abstract setW: index:float * z:float -> BufferAttribute
    abstract setXY: index:float * x:float * y:float -> BufferAttribute
    abstract setXYZ: index:float * x:float * y:float * z:float -> BufferAttribute
    abstract setXYZW: index:float * x:float * y:float * z:float * w:float -> BufferAttribute
    abstract toJSON: unit -> BufferAttributeToJSONReturn

[<AllowNullLiteral>]
type BufferAttributeToJSONReturn =
    abstract itemSize: float with get, set
    abstract ``type``: string with get, set
    abstract array: ResizeArray<float> with get, set
    abstract normalized: bool with get, set

[<AllowNullLiteral>]
type BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:ArrayLike<float> * itemSize:float * ?normalized:bool -> BufferAttribute

[<AllowNullLiteral>]
type Int8Attribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Int8AttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Int8Attribute

[<AllowNullLiteral>]
type Uint8Attribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Uint8AttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Uint8Attribute

[<AllowNullLiteral>]
type Uint8ClampedAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Uint8ClampedAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Uint8ClampedAttribute

[<AllowNullLiteral>]
type Int16Attribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Int16AttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Int16Attribute

[<AllowNullLiteral>]
type Uint16Attribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Uint16AttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Uint16Attribute

[<AllowNullLiteral>]
type Int32Attribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Int32AttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Int32Attribute

[<AllowNullLiteral>]
type Uint32Attribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Uint32AttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Uint32Attribute

[<AllowNullLiteral>]
type Float32Attribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Float32AttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Float32Attribute

[<AllowNullLiteral>]
type Float64Attribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Float64AttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:obj * itemSize:float -> Float64Attribute

[<AllowNullLiteral>]
type Int8BufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Int8BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Int8BufferAttribute

[<AllowNullLiteral>]
type Uint8BufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Uint8BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Uint8BufferAttribute

[<AllowNullLiteral>]
type Uint8ClampedBufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Uint8ClampedBufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Uint8ClampedBufferAttribute

[<AllowNullLiteral>]
type Int16BufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Int16BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Int16BufferAttribute

[<AllowNullLiteral>]
type Uint16BufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Uint16BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Uint16BufferAttribute

[<AllowNullLiteral>]
type Int32BufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Int32BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Int32BufferAttribute

[<AllowNullLiteral>]
type Uint32BufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Uint32BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Uint32BufferAttribute

[<AllowNullLiteral>]
type Float32BufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Float32BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Float32BufferAttribute

[<AllowNullLiteral>]
type Float64BufferAttribute =
    inherit BufferAttribute

[<AllowNullLiteral>]
type Float64BufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:U4<Iterable<float>, ArrayLike<float>, ArrayBuffer, float>
                     * itemSize:float
                     * ?normalized:bool
                     -> Float64BufferAttribute

[<AllowNullLiteral>]
type BufferAttributeUpdateRange =
    abstract offset: float with get, set
    abstract count: float with get, set

[<AllowNullLiteral>]
type BufferAttributeCopyColorsArray =
    abstract r: float with get, set
    abstract g: float with get, set
    abstract b: float with get, set

[<AllowNullLiteral>]
type BufferAttributeCopyVector2sArray =
    abstract x: float with get, set
    abstract y: float with get, set

[<AllowNullLiteral>]
type BufferAttributeCopyVector3sArray =
    abstract x: float with get, set
    abstract y: float with get, set
    abstract z: float with get, set

[<AllowNullLiteral>]
type BufferAttributeCopyVector4sArray =
    abstract x: float with get, set
    abstract y: float with get, set
    abstract z: float with get, set
    abstract w: float with get, set













/// This is a superefficent class for geometries because it saves all data in buffers.
/// It reduces memory costs and cpu cycles. But it is not as easy to work with because of all the necessary buffer calculations.
/// It is mainly interesting when working with static objects.
[<AllowNullLiteral>]
type BufferGeometry =
    inherit EventDispatcher
    /// Unique number of this buffergeometry instance
    abstract id: float with get, set
    abstract uuid: string with get, set
    abstract name: string with get, set
    abstract ``type``: string with get, set
    abstract index: BufferAttribute with get, set
    abstract attributes: BufferGeometryAttributes with get, set
    abstract morphAttributes: BufferGeometryMorphAttributes with get, set
    abstract morphTargetsRelative: bool with get, set
    abstract groups: ResizeArray<BufferGeometryGroups> with get, set
    abstract boundingBox: Box3 with get, set
    abstract boundingSphere: Sphere with get, set
    abstract drawRange: BufferGeometryDrawRange with get, set
    abstract userData: BufferGeometryUserData with get, set
    abstract isBufferGeometry: obj
    abstract getIndex: unit -> BufferAttribute option
    abstract setIndex: index:U2<BufferAttribute, ResizeArray<float>> option -> unit
    abstract setAttribute: name:string * attribute:U2<BufferAttribute, InterleavedBufferAttribute> -> BufferGeometry
    abstract getAttribute: name:string -> U2<BufferAttribute, InterleavedBufferAttribute>
    abstract deleteAttribute: name:string -> BufferGeometry
    abstract addGroup: start:float * count:float * ?materialIndex:float -> unit
    abstract clearGroups: unit -> unit
    abstract setDrawRange: start:float * count:float -> unit
    /// Bakes matrix transform directly into vertex coordinates.
    abstract applyMatrix4: matrix:Matrix4 -> BufferGeometry
    abstract rotateX: angle:float -> BufferGeometry
    abstract rotateY: angle:float -> BufferGeometry
    abstract rotateZ: angle:float -> BufferGeometry
    abstract translate: x:float * y:float * z:float -> BufferGeometry
    abstract scale: x:float * y:float * z:float -> BufferGeometry
    abstract lookAt: v:Vector3 -> unit
    abstract center: unit -> BufferGeometry
    abstract setFromObject: object:Object3D -> BufferGeometry
    abstract setFromPoints: points:U2<ResizeArray<Vector3>, ResizeArray<Vector2>> -> BufferGeometry
    abstract updateFromObject: object:Object3D -> unit
    abstract fromGeometry: geometry:Geometry * ?settings:obj -> BufferGeometry
    abstract fromDirectGeometry: geometry:DirectGeometry -> BufferGeometry
    /// Computes bounding box of the geometry, updating Geometry.boundingBox attribute.
    /// Bounding boxes aren't computed by default. They need to be explicitly computed, otherwise they are null.
    abstract computeBoundingBox: unit -> unit
    /// Computes bounding sphere of the geometry, updating Geometry.boundingSphere attribute.
    /// Bounding spheres aren't' computed by default. They need to be explicitly computed, otherwise they are null.
    abstract computeBoundingSphere: unit -> unit
    /// Computes vertex normals by averaging face normals.
    abstract computeVertexNormals: unit -> unit
    abstract merge: geometry:BufferGeometry * ?offset:float -> BufferGeometry
    abstract normalizeNormals: unit -> unit
    abstract toNonIndexed: unit -> BufferGeometry
    abstract toJSON: unit -> obj
    abstract clone: unit -> BufferGeometry
    abstract copy: source:BufferGeometry -> BufferGeometry
    /// Disposes the object from memory.
    /// You need to call this when you want the bufferGeometry removed while the application is running.
    abstract dispose: unit -> unit
    abstract drawcalls: obj with get, set
    abstract offsets: obj with get, set
    abstract addIndex: index:obj -> unit
    abstract addDrawCall: start:obj * count:obj * ?indexOffset:obj -> unit
    abstract clearDrawCalls: unit -> unit
    abstract addAttribute: name:string * attribute:U2<BufferAttribute, InterleavedBufferAttribute> -> BufferGeometry
    abstract removeAttribute: name:string -> BufferGeometry
    abstract addAttribute: name:obj * array:obj * itemSize:obj -> obj

/// This is a superefficent class for geometries because it saves all data in buffers.
/// It reduces memory costs and cpu cycles. But it is not as easy to work with because of all the necessary buffer calculations.
/// It is mainly interesting when working with static objects.
[<AllowNullLiteral>]
type BufferGeometryStatic =
    /// This creates a new BufferGeometry. It also sets several properties to an default value.
    [<Emit "new $0($1...)">]
    abstract Create: unit -> BufferGeometry

    abstract MaxIndex: float with get, set

[<AllowNullLiteral>]
type BufferGeometryAttributes =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: name:string -> U2<BufferAttribute, InterleavedBufferAttribute> with get, set

[<AllowNullLiteral>]
type BufferGeometryMorphAttributes =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: name:string -> ResizeArray<U2<BufferAttribute, InterleavedBufferAttribute>> with get, set

[<AllowNullLiteral>]
type BufferGeometryGroups =
    abstract start: float with get, set
    abstract count: float with get, set
    abstract materialIndex: float with get, set

[<AllowNullLiteral>]
type BufferGeometryDrawRange =
    abstract start: float with get, set
    abstract count: float with get, set

[<AllowNullLiteral>]
type BufferGeometryUserData =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: key:string -> obj with get, set


/// Object for keeping track of time.
[<AllowNullLiteral>]
type Clock =
    /// If set, starts the clock automatically when the first update is called.
    abstract autoStart: bool with get, set
    /// When the clock is running, It holds the starttime of the clock.
    /// This counted from the number of milliseconds elapsed since 1 January 1970 00:00:00 UTC.
    abstract startTime: float with get, set
    /// When the clock is running, It holds the previous time from a update.
    /// This counted from the number of milliseconds elapsed since 1 January 1970 00:00:00 UTC.
    abstract oldTime: float with get, set
    /// When the clock is running, It holds the time elapsed between the start of the clock to the previous update.
    /// This parameter is in seconds of three decimal places.
    abstract elapsedTime: float with get, set
    /// This property keeps track whether the clock is running or not.
    abstract running: bool with get, set
    /// Starts clock.
    abstract start: unit -> unit
    /// Stops clock.
    abstract stop: unit -> unit
    /// Get the seconds passed since the clock started.
    abstract getElapsedTime: unit -> float
    /// Get the seconds passed since the last call to this method.
    abstract getDelta: unit -> float

/// Object for keeping track of time.
[<AllowNullLiteral>]
type ClockStatic =
    /// <param name="autoStart">Automatically start the clock.</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?autoStart:bool -> Clock










[<AllowNullLiteral>]
type DirectGeometry =
    abstract id: float with get, set
    abstract uuid: string with get, set
    abstract name: string with get, set
    abstract ``type``: string with get, set
    abstract indices: ResizeArray<float> with get, set
    abstract vertices: ResizeArray<Vector3> with get, set
    abstract normals: ResizeArray<Vector3> with get, set
    abstract colors: ResizeArray<Color> with get, set
    abstract uvs: ResizeArray<Vector2> with get, set
    abstract uvs2: ResizeArray<Vector2> with get, set
    abstract groups: ResizeArray<DirectGeometryGroups> with get, set
    abstract morphTargets: ResizeArray<MorphTarget> with get, set
    abstract skinWeights: ResizeArray<Vector4> with get, set
    abstract skinIndices: ResizeArray<Vector4> with get, set
    abstract boundingBox: Box3 with get, set
    abstract boundingSphere: Sphere with get, set
    abstract verticesNeedUpdate: bool with get, set
    abstract normalsNeedUpdate: bool with get, set
    abstract colorsNeedUpdate: bool with get, set
    abstract uvsNeedUpdate: bool with get, set
    abstract groupsNeedUpdate: bool with get, set
    abstract computeBoundingBox: unit -> unit
    abstract computeBoundingSphere: unit -> unit
    abstract computeGroups: geometry:Geometry -> unit
    abstract fromGeometry: geometry:Geometry -> DirectGeometry
    abstract dispose: unit -> unit

[<AllowNullLiteral>]
type DirectGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> DirectGeometry

[<AllowNullLiteral>]
type DirectGeometryGroups =
    abstract start: float with get, set
    abstract materialIndex: float with get, set


/// Event object.
[<AllowNullLiteral>]
type Event =
    abstract ``type``: string with get, set
    abstract target: obj with get, set

    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: attachment:string -> obj with get, set

/// JavaScript events for custom objects
[<AllowNullLiteral>]
type EventDispatcher =
    /// <summary>Adds a listener to an event type.</summary>
    /// <param name="type">The type of event to listen to.</param>
    /// <param name="listener">The function that gets called when the event is fired.</param>
    abstract addEventListener: ``type``:string * listener:(Event -> unit) -> unit
    /// <summary>Checks if listener is added to an event type.</summary>
    /// <param name="type">The type of event to listen to.</param>
    /// <param name="listener">The function that gets called when the event is fired.</param>
    abstract hasEventListener: ``type``:string * listener:(Event -> unit) -> bool
    /// <summary>Removes a listener from an event type.</summary>
    /// <param name="type">The type of the listener that gets removed.</param>
    /// <param name="listener">The listener function that gets removed.</param>
    abstract removeEventListener: ``type``:string * listener:(Event -> unit) -> unit
    /// Fire an event type.
    abstract dispatchEvent: event:EventDispatcherDispatchEventEvent -> unit

[<AllowNullLiteral>]
type EventDispatcherDispatchEventEvent =
    abstract ``type``: string with get, set

    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: attachment:string -> obj with get, set

/// JavaScript events for custom objects
[<AllowNullLiteral>]
type EventDispatcherStatic =
    /// Creates eventDispatcher object. It needs to be call with '.call' to add the functionality to an object.
    [<Emit "new $0($1...)">]
    abstract Create: unit -> EventDispatcher




/// Triangle face.
[<AllowNullLiteral>]
type Face3 =
    /// Vertex A index.
    abstract a: float with get, set
    /// Vertex B index.
    abstract b: float with get, set
    /// Vertex C index.
    abstract c: float with get, set
    /// Face normal.
    abstract normal: Vector3 with get, set
    /// Array of 3 vertex normals.
    abstract vertexNormals: ResizeArray<Vector3> with get, set
    /// Face color.
    abstract color: Color with get, set
    /// Array of 3 vertex colors.
    abstract vertexColors: ResizeArray<Color> with get, set
    /// Material index (points to {@link Geometry.materials}).
    abstract materialIndex: float with get, set
    abstract clone: unit -> Face3
    abstract copy: source:Face3 -> Face3

/// Triangle face.
[<AllowNullLiteral>]
type Face3Static =
    /// <param name="a">Vertex A index.</param>
    /// <param name="b">Vertex B index.</param>
    /// <param name="c">Vertex C index.</param>
    /// <param name="normal">Face normal or array of vertex normals.</param>
    /// <param name="color">Face color or array of vertex colors.</param>
    /// <param name="materialIndex">Material index.</param>
    [<Emit "new $0($1...)">]
    abstract Create: a:float * b:float * c:float * ?normal:Vector3 * ?color:Color * ?materialIndex:float -> Face3

    [<Emit "new $0($1...)">]
    abstract Create: a:float
                     * b:float
                     * c:float
                     * ?normal:Vector3
                     * ?vertexColors:ResizeArray<Color>
                     * ?materialIndex:float
                     -> Face3

    [<Emit "new $0($1...)">]
    abstract Create: a:float
                     * b:float
                     * c:float
                     * ?vertexNormals:ResizeArray<Vector3>
                     * ?color:Color
                     * ?materialIndex:float
                     -> Face3

    [<Emit "new $0($1...)">]
    abstract Create: a:float
                     * b:float
                     * c:float
                     * ?vertexNormals:ResizeArray<Vector3>
                     * ?vertexColors:ResizeArray<Color>
                     * ?materialIndex:float
                     -> Face3














[<Import("GeometryIdCount", "three")>]
let GeometryIdCount: float = jsNative


[<AllowNullLiteral>]
type MorphTarget =
    abstract name: string with get, set
    abstract vertices: ResizeArray<Vector3> with get, set

[<AllowNullLiteral>]
type MorphColor =
    abstract name: string with get, set
    abstract colors: ResizeArray<Color> with get, set

[<AllowNullLiteral>]
type MorphNormals =
    abstract name: string with get, set
    abstract normals: ResizeArray<Vector3> with get, set

/// Base class for geometries
[<AllowNullLiteral>]
type Geometry =
    inherit EventDispatcher
    /// Unique number of this geometry instance
    abstract id: float with get, set
    abstract uuid: string with get, set
    abstract isGeometry: obj
    /// Name for this geometry. Default is an empty string.
    abstract name: string with get, set
    abstract ``type``: string with get, set
    /// The array of vertices hold every position of points of the model.
    /// To signal an update in this array, Geometry.verticesNeedUpdate needs to be set to true.
    abstract vertices: ResizeArray<Vector3> with get, set
    /// Array of vertex colors, matching number and order of vertices.
    /// Used in ParticleSystem, Line and Ribbon.
    /// Meshes use per-face-use-of-vertex colors embedded directly in faces.
    /// To signal an update in this array, Geometry.colorsNeedUpdate needs to be set to true.
    abstract colors: ResizeArray<Color> with get, set
    /// Array of triangles or/and quads.
    /// The array of faces describe how each vertex in the model is connected with each other.
    /// To signal an update in this array, Geometry.elementsNeedUpdate needs to be set to true.
    abstract faces: ResizeArray<Face3> with get, set
    /// Array of face UV layers.
    /// Each UV layer is an array of UV matching order and number of vertices in faces.
    /// To signal an update in this array, Geometry.uvsNeedUpdate needs to be set to true.
    abstract faceVertexUvs: ResizeArray<ResizeArray<ResizeArray<Vector2>>> with get, set
    /// Array of morph targets. Each morph target is a Javascript object:
    ///
    /// 		 { name: "targetName", vertices: [ new THREE.Vector3(), ... ] }
    ///
    /// Morph vertices match number and order of primary vertices.
    abstract morphTargets: ResizeArray<MorphTarget> with get, set
    /// Array of morph normals. Morph normals have similar structure as morph targets, each normal set is a Javascript object:
    ///
    /// 		 morphNormal = { name: "NormalName", normals: [ new THREE.Vector3(), ... ] }
    abstract morphNormals: ResizeArray<MorphNormals> with get, set
    /// Array of skinning weights, matching number and order of vertices.
    abstract skinWeights: ResizeArray<Vector4> with get, set
    /// Array of skinning indices, matching number and order of vertices.
    abstract skinIndices: ResizeArray<Vector4> with get, set
    abstract lineDistances: ResizeArray<float> with get, set
    /// Bounding box.
    abstract boundingBox: Box3 with get, set
    /// Bounding sphere.
    abstract boundingSphere: Sphere with get, set
    /// Set to true if the vertices array has been updated.
    abstract verticesNeedUpdate: bool with get, set
    /// Set to true if the faces array has been updated.
    abstract elementsNeedUpdate: bool with get, set
    /// Set to true if the uvs array has been updated.
    abstract uvsNeedUpdate: bool with get, set
    /// Set to true if the normals array has been updated.
    abstract normalsNeedUpdate: bool with get, set
    /// Set to true if the colors array has been updated.
    abstract colorsNeedUpdate: bool with get, set
    /// Set to true if the linedistances array has been updated.
    abstract lineDistancesNeedUpdate: bool with get, set
    abstract groupsNeedUpdate: bool with get, set
    /// Bakes matrix transform directly into vertex coordinates.
    abstract applyMatrix4: matrix:Matrix4 -> Geometry
    abstract rotateX: angle:float -> Geometry
    abstract rotateY: angle:float -> Geometry
    abstract rotateZ: angle:float -> Geometry
    abstract translate: x:float * y:float * z:float -> Geometry
    abstract scale: x:float * y:float * z:float -> Geometry
    abstract lookAt: vector:Vector3 -> unit
    abstract fromBufferGeometry: geometry:BufferGeometry -> Geometry
    abstract center: unit -> Geometry
    abstract normalize: unit -> Geometry
    /// Computes face normals.
    abstract computeFaceNormals: unit -> unit
    /// Computes vertex normals by averaging face normals.
    /// Face normals must be existing / computed beforehand.
    abstract computeVertexNormals: ?areaWeighted:bool -> unit
    /// Compute vertex normals, but duplicating face normals.
    abstract computeFlatVertexNormals: unit -> unit
    /// Computes morph normals.
    abstract computeMorphNormals: unit -> unit
    /// Computes bounding box of the geometry, updating {@link Geometry.boundingBox} attribute.
    abstract computeBoundingBox: unit -> unit
    /// Computes bounding sphere of the geometry, updating Geometry.boundingSphere attribute.
    /// Neither bounding boxes or bounding spheres are computed by default. They need to be explicitly computed, otherwise they are null.
    abstract computeBoundingSphere: unit -> unit
    abstract merge: geometry:Geometry * ?matrix:Matrix * ?materialIndexOffset:float -> unit
    abstract mergeMesh: mesh:Mesh -> unit
    /// Checks for duplicate vertices using hashmap.
    /// Duplicated vertices are removed and faces' vertices are updated.
    abstract mergeVertices: unit -> float
    abstract setFromPoints: points:U2<Array<Vector2>, Array<Vector3>> -> Geometry
    abstract sortFacesByMaterialIndex: unit -> unit
    abstract toJSON: unit -> obj
    /// Creates a new clone of the Geometry.
    abstract clone: unit -> Geometry
    abstract copy: source:Geometry -> Geometry
    /// Removes The object from memory.
    /// Don't forget to call this method when you remove an geometry because it can cuase meomory leaks.
    abstract dispose: unit -> unit
    abstract bones: ResizeArray<Bone> with get, set
    abstract animation: AnimationClip with get, set
    abstract animations: ResizeArray<AnimationClip> with get, set

/// Base class for geometries
[<AllowNullLiteral>]
type GeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Geometry


[<Import("BufferGeometryUtils", "three")>]
let bufferGeometryUtils: BufferGeometryUtils.IExports = jsNative

[<Import("GeometryUtils", "three")>]
let geometryUtils: GeometryUtils.IExports = jsNative


module BufferGeometryUtils =

    [<AllowNullLiteral>]
    type IExports =
        abstract mergeBufferGeometries: geometries:ResizeArray<BufferGeometry> -> BufferGeometry
        abstract computeTangents: geometry:BufferGeometry -> obj
        abstract mergeBufferAttributes: attributes:ResizeArray<BufferAttribute> -> BufferAttribute

module GeometryUtils =

    [<AllowNullLiteral>]
    type IExports =
        abstract merge: geometry1:obj * geometry2:obj * ?materialIndexOffset:obj -> obj
        abstract center: geometry:obj -> obj

[<AllowNullLiteral>]
type InstancedBufferAttribute =
    inherit BufferAttribute
    abstract meshPerAttribute: float with get, set

[<AllowNullLiteral>]
type InstancedBufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:ArrayLike<float>
                     * itemSize:float
                     * ?normalized:bool
                     * ?meshPerAttribute:float
                     -> InstancedBufferAttribute



[<AllowNullLiteral>]
type InstancedBufferGeometry =
    inherit BufferGeometry
    abstract groups: ResizeArray<InstancedBufferGeometryGroups> with get, set
    abstract instanceCount: float with get, set
    abstract addGroup: start:float * count:float * instances:float -> unit

[<AllowNullLiteral>]
type InstancedBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> InstancedBufferGeometry

[<AllowNullLiteral>]
type InstancedBufferGeometryGroups =
    abstract start: float with get, set
    abstract count: float with get, set
    abstract instances: float with get, set



[<AllowNullLiteral>]
type InstancedInterleavedBuffer =
    inherit InterleavedBuffer
    abstract meshPerAttribute: float with get, set

[<AllowNullLiteral>]
type InstancedInterleavedBufferStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:ArrayLike<float> * stride:float * ?meshPerAttribute:float -> InstancedInterleavedBuffer




[<AllowNullLiteral>]
type InterleavedBuffer =
    abstract array: ArrayLike<float> with get, set
    abstract stride: float with get, set
    abstract usage: Usage with get, set
    abstract updateRange: InterleavedBufferUpdateRange with get, set
    abstract version: float with get, set
    abstract length: float with get, set
    abstract count: float with get, set
    abstract needsUpdate: bool with get, set
    abstract uuid: string with get, set
    abstract setUsage: usage:Usage -> InterleavedBuffer
    abstract clone: data:obj -> InterleavedBuffer
    abstract copy: source:InterleavedBuffer -> InterleavedBuffer
    abstract copyAt: index1:float * attribute:InterleavedBufferAttribute * index2:float -> InterleavedBuffer
    abstract set: value:ArrayLike<float> * index:float -> InterleavedBuffer
    abstract toJSON: data:obj -> InterleavedBufferToJSONReturn

[<AllowNullLiteral>]
type InterleavedBufferToJSONReturn =
    abstract uuid: string with get, set
    abstract buffer: string with get, set
    abstract ``type``: string with get, set
    abstract stride: float with get, set

[<AllowNullLiteral>]
type InterleavedBufferStatic =
    [<Emit "new $0($1...)">]
    abstract Create: array:ArrayLike<float> * stride:float -> InterleavedBuffer

[<AllowNullLiteral>]
type InterleavedBufferUpdateRange =
    abstract offset: float with get, set
    abstract count: float with get, set





[<AllowNullLiteral>]
type InterleavedBufferAttribute =
    abstract name: string with get, set
    abstract data: InterleavedBuffer with get, set
    abstract itemSize: float with get, set
    abstract offset: float with get, set
    abstract normalized: bool with get, set
    abstract isInterleavedBufferAttribute: obj
    abstract applyMatrix4: m:Matrix4 -> InterleavedBufferAttribute
    abstract clone: ?data:obj -> BufferAttribute
    abstract getX: index:float -> float
    abstract setX: index:float * x:float -> InterleavedBufferAttribute
    abstract getY: index:float -> float
    abstract setY: index:float * y:float -> InterleavedBufferAttribute
    abstract getZ: index:float -> float
    abstract setZ: index:float * z:float -> InterleavedBufferAttribute
    abstract getW: index:float -> float
    abstract setW: index:float * z:float -> InterleavedBufferAttribute
    abstract setXY: index:float * x:float * y:float -> InterleavedBufferAttribute
    abstract setXYZ: index:float * x:float * y:float * z:float -> InterleavedBufferAttribute
    abstract setXYZW: index:float * x:float * y:float * z:float * w:float -> InterleavedBufferAttribute
    abstract toJSON: ?data:obj -> InterleavedBufferAttributeToJSONReturn

[<AllowNullLiteral>]
type InterleavedBufferAttributeToJSONReturn =
    abstract isInterleavedBufferAttribute: obj with get, set
    abstract itemSize: float with get, set
    abstract data: string with get, set
    abstract offset: float with get, set
    abstract normalized: bool with get, set

[<AllowNullLiteral>]
type InterleavedBufferAttributeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: interleavedBuffer:InterleavedBuffer
                     * itemSize:float
                     * offset:float
                     * ?normalized:bool
                     -> InterleavedBufferAttribute


[<AllowNullLiteral>]
type Layers =
    abstract mask: float with get, set
    abstract set: channel:float -> unit
    abstract enable: channel:float -> unit
    abstract enableAll: unit -> unit
    abstract toggle: channel:float -> unit
    abstract disable: channel:float -> unit
    abstract disableAll: unit -> unit
    abstract test: layers:Layers -> bool

[<AllowNullLiteral>]
type LayersStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Layers
















[<Import("Object3DIdCount", "three")>]
let Object3DIdCount: float = jsNative


/// Base class for scene graph objects
[<AllowNullLiteral>]
type Object3D =
    inherit EventDispatcher
    /// Unique number of this object instance.
    abstract id: float with get, set
    abstract uuid: string with get, set
    /// Optional name of the object (doesn't need to be unique).
    abstract name: string with get, set
    abstract ``type``: string with get, set
    /// Object's parent in the scene graph.
    abstract parent: Object3D with get, set
    /// Array with object's children.
    abstract children: ResizeArray<Object3D> with get, set
    /// Up direction.
    abstract up: Vector3 with get, set
    /// Object's local position.
    abstract position: Vector3
    /// Object's local rotation (Euler angles), in radians.
    abstract rotation: Euler
    /// Global rotation.
    abstract quaternion: Quaternion
    /// Object's local scale.
    abstract scale: Vector3
    abstract modelViewMatrix: Matrix4
    abstract normalMatrix: Matrix3
    /// Local transform.
    abstract matrix: Matrix4 with get, set
    /// The global transform of the object. If the Object3d has no parent, then it's identical to the local transform.
    abstract matrixWorld: Matrix4 with get, set
    /// When this is set, it calculates the matrix of position, (rotation or quaternion) and scale every frame and also recalculates the matrixWorld property.
    abstract matrixAutoUpdate: bool with get, set
    /// When this is set, it calculates the matrixWorld in that frame and resets this property to false.
    abstract matrixWorldNeedsUpdate: bool with get, set
    abstract layers: Layers with get, set
    /// Object gets rendered if true.
    abstract visible: bool with get, set
    /// Gets rendered into shadow map.
    abstract castShadow: bool with get, set
    /// Material gets baked in shadow receiving.
    abstract receiveShadow: bool with get, set
    /// When this is set, it checks every frame if the object is in the frustum of the camera. Otherwise the object gets drawn every frame even if it isn't visible.
    abstract frustumCulled: bool with get, set
    /// Overrides the default rendering order of scene graph objects, from lowest to highest renderOrder. Opaque and transparent objects remain sorted independently though. When this property is set for an instance of Group, all descendants objects will be sorted and rendered together.
    abstract renderOrder: float with get, set
    /// An object that can be used to store custom data about the Object3d. It should not hold references to functions as these will not be cloned.
    abstract userData: Object3DUserData with get, set
    /// Custom depth material to be used when rendering to the depth map. Can only be used in context of meshes.
    /// When shadow-casting with a DirectionalLight or SpotLight, if you are (a) modifying vertex positions in
    /// the vertex shader, (b) using a displacement map, (c) using an alpha map with alphaTest, or (d) using a
    /// transparent texture with alphaTest, you must specify a customDepthMaterial for proper shadows.
    abstract customDepthMaterial: Material with get, set
    /// Same as customDepthMaterial, but used with PointLight.
    abstract customDistanceMaterial: Material with get, set
    /// Used to check whether this or derived classes are Object3Ds. Default is true.
    /// You should not change this, as it is used internally for optimisation.
    abstract isObject3D: obj
    /// Calls before rendering object
    abstract onBeforeRender: (WebGLRenderer -> Scene -> Camera -> U2<Geometry, BufferGeometry> -> Material -> Group -> unit) with get, set
    /// Calls after rendering object
    abstract onAfterRender: (WebGLRenderer -> Scene -> Camera -> U2<Geometry, BufferGeometry> -> Material -> Group -> unit) with get, set
    /// This updates the position, rotation and scale with the matrix.
    abstract applyMatrix4: matrix:Matrix4 -> unit
    abstract applyQuaternion: quaternion:Quaternion -> Object3D
    abstract setRotationFromAxisAngle: axis:Vector3 * angle:float -> unit
    abstract setRotationFromEuler: euler:Euler -> unit
    abstract setRotationFromMatrix: m:Matrix4 -> unit
    abstract setRotationFromQuaternion: q:Quaternion -> unit
    /// <summary>Rotate an object along an axis in object space. The axis is assumed to be normalized.</summary>
    /// <param name="axis">A normalized vector in object space.</param>
    /// <param name="angle">The angle in radians.</param>
    abstract rotateOnAxis: axis:Vector3 * angle:float -> Object3D
    /// <summary>Rotate an object along an axis in world space. The axis is assumed to be normalized. Method Assumes no rotated parent.</summary>
    /// <param name="axis">A normalized vector in object space.</param>
    /// <param name="angle">The angle in radians.</param>
    abstract rotateOnWorldAxis: axis:Vector3 * angle:float -> Object3D
    abstract rotateX: angle:float -> Object3D
    abstract rotateY: angle:float -> Object3D
    abstract rotateZ: angle:float -> Object3D
    /// <param name="axis">A normalized vector in object space.</param>
    /// <param name="distance">The distance to translate.</param>
    abstract translateOnAxis: axis:Vector3 * distance:float -> Object3D
    /// <summary>Translates object along x axis by distance.</summary>
    /// <param name="distance">Distance.</param>
    abstract translateX: distance:float -> Object3D
    /// <summary>Translates object along y axis by distance.</summary>
    /// <param name="distance">Distance.</param>
    abstract translateY: distance:float -> Object3D
    /// <summary>Translates object along z axis by distance.</summary>
    /// <param name="distance">Distance.</param>
    abstract translateZ: distance:float -> Object3D
    /// <summary>Updates the vector from local space to world space.</summary>
    /// <param name="vector">A local vector.</param>
    abstract localToWorld: vector:Vector3 -> Vector3
    /// <summary>Updates the vector from world space to local space.</summary>
    /// <param name="vector">A world vector.</param>
    abstract worldToLocal: vector:Vector3 -> Vector3
    /// <summary>Rotates object to face point in space.</summary>
    /// <param name="vector">A world vector to look at.</param>
    abstract lookAt: vector:U2<Vector3, float> * ?y:float * ?z:float -> unit
    /// Adds object as child of this object.
    abstract add: [<ParamArray>] object:obj array -> Object3D
    /// Removes object as child of this object.
    abstract remove: [<ParamArray>] object:ResizeArray<Object3D> -> Object3D
    /// Adds object as a child of this, while maintaining the object's world transform.
    abstract attach: object:Object3D -> Object3D
    /// <summary>Searches through the object's children and returns the first with a matching id.</summary>
    /// <param name="id">Unique number of the object instance</param>
    abstract getObjectById: id:float -> Object3D option
    /// <summary>Searches through the object's children and returns the first with a matching name.</summary>
    /// <param name="name">String to match to the children's Object3d.name property.</param>
    abstract getObjectByName: name:string -> Object3D option
    abstract getObjectByProperty: name:string * value:string -> Object3D option
    abstract getWorldPosition: target:Vector3 -> Vector3
    abstract getWorldQuaternion: target:Quaternion -> Quaternion
    abstract getWorldScale: target:Vector3 -> Vector3
    abstract getWorldDirection: target:Vector3 -> Vector3
    abstract raycast: raycaster:Raycaster * intersects:ResizeArray<Intersection> -> unit
    abstract traverse: callback:(Object3D -> obj) -> unit
    abstract traverseVisible: callback:(Object3D -> obj) -> unit
    abstract traverseAncestors: callback:(Object3D -> obj) -> unit
    /// Updates local transform.
    abstract updateMatrix: unit -> unit
    /// Updates global transform of the object and its children.
    abstract updateMatrixWorld: ?force:bool -> unit
    abstract updateWorldMatrix: updateParents:bool * updateChildren:bool -> unit
    abstract toJSON: ?meta:Object3DToJSONMeta -> obj
    abstract clone: ?recursive:bool -> Object3D
    abstract copy: source:Object3D * ?recursive:bool -> Object3D

[<AllowNullLiteral>]
type Object3DToJSONMeta =
    abstract geometries: obj with get, set
    abstract materials: obj with get, set
    abstract textures: obj with get, set
    abstract images: obj with get, set

/// Base class for scene graph objects
[<AllowNullLiteral>]
type Object3DStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Object3D

    abstract DefaultUp: Vector3 with get, set
    abstract DefaultMatrixAutoUpdate: bool with get, set

[<AllowNullLiteral>]
type Object3DUserData =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: key:string -> obj with get, set









[<AllowNullLiteral>]
type Intersection =
    abstract distance: float with get, set
    abstract distanceToRay: float with get, set
    abstract point: Vector3 with get, set
    abstract index: float with get, set
    abstract face: Face3 with get, set
    abstract faceIndex: float with get, set
    abstract object: Object3D with get, set
    abstract uv: Vector2 with get, set
    abstract instanceId: float with get, set

[<AllowNullLiteral>]
type RaycasterParameters =
    abstract Mesh: obj with get, set
    abstract Line: RaycasterParametersLine with get, set
    abstract LOD: obj with get, set
    abstract Points: RaycasterParametersLine with get, set
    abstract Sprite: obj with get, set

[<AllowNullLiteral>]
type Raycaster =
    /// The Ray used for the raycasting.
    abstract ray: Ray with get, set
    /// The near factor of the raycaster. This value indicates which objects can be discarded based on the
    /// distance. This value shouldn't be negative and should be smaller than the far property.
    abstract near: float with get, set
    /// The far factor of the raycaster. This value indicates which objects can be discarded based on the
    /// distance. This value shouldn't be negative and should be larger than the near property.
    abstract far: float with get, set
    /// The camera to use when raycasting against view-dependent objects such as billboarded objects like Sprites. This field
    /// can be set manually or is set when calling "setFromCamera".
    abstract camera: Camera with get, set
    /// Used by Raycaster to selectively ignore 3D objects when performing intersection tests.
    abstract layers: Layers with get, set
    abstract ``params``: RaycasterParameters with get, set
    /// <summary>Updates the ray with a new origin and direction.</summary>
    /// <param name="origin">The origin vector where the ray casts from.</param>
    /// <param name="direction">The normalized direction vector that gives direction to the ray.</param>
    abstract set: origin:Vector3 * direction:Vector3 -> unit
    /// <summary>Updates the ray with a new origin and direction.</summary>
    /// <param name="coords">2D coordinates of the mouse, in normalized device coordinates (NDC)---X and Y components should be between -1 and 1.</param>
    /// <param name="camera">camera from which the ray should originate</param>
    abstract setFromCamera: coords:RaycasterSetFromCameraCoords * camera:Camera -> unit
    /// <summary>Checks all intersection between the ray and the object with or without the descendants. Intersections are returned sorted by distance, closest first.</summary>
    /// <param name="object">The object to check for intersection with the ray.</param>
    /// <param name="recursive">If true, it also checks all descendants. Otherwise it only checks intersecton with the object. Default is false.</param>
    /// <param name="optionalTarget">(optional) target to set the result. Otherwise a new Array is instantiated. If set, you must clear this array prior to each call (i.e., array.length = 0;).</param>
    abstract intersectObject: object:Object3D
                              * ?recursive:bool
                              * ?optionalTarget:ResizeArray<Intersection>
                              -> ResizeArray<Intersection>
    /// <summary>Checks all intersection between the ray and the objects with or without the descendants. Intersections are returned sorted by distance, closest first. Intersections are of the same form as those returned by .intersectObject.</summary>
    /// <param name="objects">The objects to check for intersection with the ray.</param>
    /// <param name="recursive">If true, it also checks all descendants of the objects. Otherwise it only checks intersecton with the objects. Default is false.</param>
    /// <param name="optionalTarget">(optional) target to set the result. Otherwise a new Array is instantiated. If set, you must clear this array prior to each call (i.e., array.length = 0;).</param>
    abstract intersectObjects: objects:ResizeArray<Object3D>
                               * ?recursive:bool
                               * ?optionalTarget:ResizeArray<Intersection>
                               -> ResizeArray<Intersection>

[<AllowNullLiteral>]
type RaycasterSetFromCameraCoords =
    abstract x: float with get, set
    abstract y: float with get, set

[<AllowNullLiteral>]
type RaycasterStatic =
    /// <summary>This creates a new raycaster object.</summary>
    /// <param name="origin">The origin vector where the ray casts from.</param>
    /// <param name="direction">The direction vector that gives direction to the ray. Should be normalized.</param>
    /// <param name="near">All results returned are further away than near. Near can't be negative. Default value is 0.</param>
    /// <param name="far">All results returned are closer then far. Far can't be lower then near . Default value is Infinity.</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?origin:Vector3 * ?direction:Vector3 * ?near:float * ?far:float -> Raycaster

[<AllowNullLiteral>]
type RaycasterParametersLine =
    abstract threshold: float with get, set


[<AllowNullLiteral>]
type Uniform =
    abstract ``type``: string with get, set
    abstract value: obj with get, set
    abstract dynamic: bool with get, set
    abstract onUpdateCallback: Function with get, set
    abstract onUpdate: callback:Function -> Uniform

[<AllowNullLiteral>]
type UniformStatic =
    [<Emit "new $0($1...)">]
    abstract Create: value:obj -> Uniform

    [<Emit "new $0($1...)">]
    abstract Create: ``type``:string * value:obj -> Uniform


[<Import("ImageUtils", "three")>]
let imageUtils: ImageUtils.IExports = jsNative

module ImageUtils =

    [<AllowNullLiteral>]
    type IExports =
        abstract getDataURL: image:obj -> string
        abstract crossOrigin: string

        abstract loadTexture: url:string
                              * ?mapping:Mapping
                              * ?onLoad:(Texture -> unit)
                              * ?onError:(string -> unit)
                              -> Texture

        abstract loadTextureCube: array:ResizeArray<string>
                                  * ?mapping:Mapping
                                  * ?onLoad:(Texture -> unit)
                                  * ?onError:(string -> unit)
                                  -> Texture







[<AllowNullLiteral>]
type PMREMGenerator =
    abstract fromScene: scene:Scene * ?sigma:float * ?near:float * ?far:float -> WebGLRenderTarget
    abstract fromEquirectangular: equirectangular:Texture -> WebGLRenderTarget
    abstract fromCubemap: cubemap:CubeTexture -> WebGLRenderTarget
    abstract compileCubemapShader: unit -> unit
    abstract compileEquirectangularShader: unit -> unit
    abstract dispose: unit -> unit

[<AllowNullLiteral>]
type PMREMGeneratorStatic =
    [<Emit "new $0($1...)">]
    abstract Create: renderer:WebGLRenderer -> PMREMGenerator

[<Import("ShapeUtils", "three")>]
let shapeUtils: ShapeUtils.IExports = jsNative

[<AllowNullLiteral>]
type Vec2 =
    abstract x: float with get, set
    abstract y: float with get, set

module ShapeUtils =

    [<AllowNullLiteral>]
    type IExports =
        abstract area: contour:ResizeArray<Vec2> -> float

        abstract triangulateShape: contour:ResizeArray<Vec2>
                                   * holes:ResizeArray<ResizeArray<Vec2>>
                                   -> ResizeArray<ResizeArray<float>>

        abstract isClockWise: pts:ResizeArray<Vec2> -> bool





[<AllowNullLiteral>]
type BoxBufferGeometry =
    inherit BufferGeometry
    abstract parameters: BoxBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type BoxBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?width:float
                     * ?height:float
                     * ?depth:float
                     * ?widthSegments:float
                     * ?heightSegments:float
                     * ?depthSegments:float
                     -> BoxBufferGeometry

/// BoxGeometry is the quadrilateral primitive geometry class. It is typically used for creating a cube or irregular quadrilateral of the dimensions provided within the (optional) 'width', 'height', & 'depth' constructor arguments.
[<AllowNullLiteral>]
type BoxGeometry =
    inherit Geometry
    abstract parameters: BoxBufferGeometryParameters with get, set

/// BoxGeometry is the quadrilateral primitive geometry class. It is typically used for creating a cube or irregular quadrilateral of the dimensions provided within the (optional) 'width', 'height', & 'depth' constructor arguments.
[<AllowNullLiteral>]
type BoxGeometryStatic =
    /// <param name="width">— Width of the sides on the X axis.</param>
    /// <param name="height">— Height of the sides on the Y axis.</param>
    /// <param name="depth">— Depth of the sides on the Z axis.</param>
    /// <param name="widthSegments">— Number of segmented faces along the width of the sides.</param>
    /// <param name="heightSegments">— Number of segmented faces along the height of the sides.</param>
    /// <param name="depthSegments">— Number of segmented faces along the depth of the sides.</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?width:float
                     * ?height:float
                     * ?depth:float
                     * ?widthSegments:float
                     * ?heightSegments:float
                     * ?depthSegments:float
                     -> BoxGeometry

[<AllowNullLiteral>]
type BoxBufferGeometryParameters =
    abstract width: float with get, set
    abstract height: float with get, set
    abstract depth: float with get, set
    abstract widthSegments: float with get, set
    abstract heightSegments: float with get, set
    abstract depthSegments: float with get, set





[<AllowNullLiteral>]
type CircleBufferGeometry =
    inherit BufferGeometry
    abstract parameters: CircleBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type CircleBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?segments:float * ?thetaStart:float * ?thetaLength:float -> CircleBufferGeometry

[<AllowNullLiteral>]
type CircleGeometry =
    inherit Geometry
    abstract parameters: CircleBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type CircleGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?segments:float * ?thetaStart:float * ?thetaLength:float -> CircleGeometry

[<AllowNullLiteral>]
type CircleBufferGeometryParameters =
    abstract radius: float with get, set
    abstract segments: float with get, set
    abstract thetaStart: float with get, set
    abstract thetaLength: float with get, set





[<AllowNullLiteral>]
type ConeBufferGeometry =
    inherit CylinderBufferGeometry

[<AllowNullLiteral>]
type ConeBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float
                     * ?height:float
                     * ?radialSegment:float
                     * ?heightSegment:float
                     * ?openEnded:bool
                     * ?thetaStart:float
                     * ?thetaLength:float
                     -> ConeBufferGeometry

[<AllowNullLiteral>]
type ConeGeometry =
    inherit CylinderGeometry

[<AllowNullLiteral>]
type ConeGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float
                     * ?height:float
                     * ?radialSegment:float
                     * ?heightSegment:float
                     * ?openEnded:bool
                     * ?thetaStart:float
                     * ?thetaLength:float
                     -> ConeGeometry





[<AllowNullLiteral>]
type CylinderBufferGeometry =
    inherit BufferGeometry
    abstract parameters: CylinderBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type CylinderBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radiusTop:float
                     * ?radiusBottom:float
                     * ?height:float
                     * ?radialSegments:float
                     * ?heightSegments:float
                     * ?openEnded:bool
                     * ?thetaStart:float
                     * ?thetaLength:float
                     -> CylinderBufferGeometry

[<AllowNullLiteral>]
type CylinderGeometry =
    inherit Geometry
    abstract parameters: CylinderBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type CylinderGeometryStatic =
    /// <param name="radiusTop">— Radius of the cylinder at the top.</param>
    /// <param name="radiusBottom">— Radius of the cylinder at the bottom.</param>
    /// <param name="height">— Height of the cylinder.</param>
    /// <param name="radiusSegments">— Number of segmented faces around the circumference of the cylinder.</param>
    /// <param name="heightSegments">— Number of rows of faces along the height of the cylinder.</param>
    /// <param name="openEnded">- A Boolean indicating whether or not to cap the ends of the cylinder.</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?radiusTop:float
                     * ?radiusBottom:float
                     * ?height:float
                     * ?radiusSegments:float
                     * ?heightSegments:float
                     * ?openEnded:bool
                     * ?thetaStart:float
                     * ?thetaLength:float
                     -> CylinderGeometry

[<AllowNullLiteral>]
type CylinderBufferGeometryParameters =
    abstract radiusTop: float with get, set
    abstract radiusBottom: float with get, set
    abstract height: float with get, set
    abstract radialSegments: float with get, set
    abstract heightSegments: float with get, set
    abstract openEnded: bool with get, set
    abstract thetaStart: float with get, set
    abstract thetaLength: float with get, set





[<AllowNullLiteral>]
type DodecahedronBufferGeometry =
    inherit PolyhedronBufferGeometry

[<AllowNullLiteral>]
type DodecahedronBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?detail:float -> DodecahedronBufferGeometry

[<AllowNullLiteral>]
type DodecahedronGeometry =
    inherit Geometry
    abstract parameters: DodecahedronGeometryParameters with get, set

[<AllowNullLiteral>]
type DodecahedronGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?detail:float -> DodecahedronGeometry

[<AllowNullLiteral>]
type DodecahedronGeometryParameters =
    abstract radius: float with get, set
    abstract detail: float with get, set




[<AllowNullLiteral>]
type EdgesGeometry =
    inherit BufferGeometry

[<AllowNullLiteral>]
type EdgesGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: geometry:U2<BufferGeometry, Geometry> * ?thresholdAngle:float -> EdgesGeometry









[<AllowNullLiteral>]
type ExtrudeGeometryOptions =
    abstract curveSegments: float with get, set
    abstract steps: float with get, set
    abstract depth: float with get, set
    abstract bevelEnabled: bool with get, set
    abstract bevelThickness: float with get, set
    abstract bevelSize: float with get, set
    abstract bevelOffset: float with get, set
    abstract bevelSegments: float with get, set
    abstract extrudePath: Curve<Vector3> with get, set
    abstract UVGenerator: UVGenerator with get, set

[<AllowNullLiteral>]
type UVGenerator =
    abstract generateTopUV: geometry:ExtrudeBufferGeometry
                            * vertices:ResizeArray<float>
                            * indexA:float
                            * indexB:float
                            * indexC:float
                            -> ResizeArray<Vector2>

    abstract generateSideWallUV: geometry:ExtrudeBufferGeometry
                                 * vertices:ResizeArray<float>
                                 * indexA:float
                                 * indexB:float
                                 * indexC:float
                                 * indexD:float
                                 -> ResizeArray<Vector2>

[<AllowNullLiteral>]
type ExtrudeBufferGeometry =
    inherit BufferGeometry
    abstract addShapeList: shapes:ResizeArray<Shape> * ?options:obj -> unit
    abstract addShape: shape:Shape * ?options:obj -> unit

[<AllowNullLiteral>]
type ExtrudeBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: shapes:U2<Shape, ResizeArray<Shape>> * ?options:ExtrudeGeometryOptions -> ExtrudeBufferGeometry

    abstract WorldUVGenerator: UVGenerator with get, set

[<AllowNullLiteral>]
type ExtrudeGeometry =
    inherit Geometry
    abstract addShapeList: shapes:ResizeArray<Shape> * ?options:obj -> unit
    abstract addShape: shape:Shape * ?options:obj -> unit

[<AllowNullLiteral>]
type ExtrudeGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: shapes:U2<Shape, ResizeArray<Shape>> * ?options:ExtrudeGeometryOptions -> ExtrudeGeometry

    abstract WorldUVGenerator: UVGenerator with get, set





[<AllowNullLiteral>]
type IcosahedronBufferGeometry =
    inherit PolyhedronBufferGeometry

[<AllowNullLiteral>]
type IcosahedronBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?detail:float -> IcosahedronBufferGeometry

[<AllowNullLiteral>]
type IcosahedronGeometry =
    inherit PolyhedronGeometry

[<AllowNullLiteral>]
type IcosahedronGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?detail:float -> IcosahedronGeometry






[<AllowNullLiteral>]
type LatheBufferGeometry =
    inherit BufferGeometry
    abstract parameters: LatheBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type LatheBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: points:ResizeArray<Vector2>
                     * ?segments:float
                     * ?phiStart:float
                     * ?phiLength:float
                     -> LatheBufferGeometry

[<AllowNullLiteral>]
type LatheGeometry =
    inherit Geometry
    abstract parameters: LatheBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type LatheGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: points:ResizeArray<Vector2> * ?segments:float * ?phiStart:float * ?phiLength:float -> LatheGeometry

[<AllowNullLiteral>]
type LatheBufferGeometryParameters =
    abstract points: ResizeArray<Vector2> with get, set
    abstract segments: float with get, set
    abstract phiStart: float with get, set
    abstract phiLength: float with get, set





[<AllowNullLiteral>]
type OctahedronBufferGeometry =
    inherit PolyhedronBufferGeometry

[<AllowNullLiteral>]
type OctahedronBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?detail:float -> OctahedronBufferGeometry

[<AllowNullLiteral>]
type OctahedronGeometry =
    inherit PolyhedronGeometry

[<AllowNullLiteral>]
type OctahedronGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?detail:float -> OctahedronGeometry






[<AllowNullLiteral>]
type ParametricBufferGeometry =
    inherit BufferGeometry
    abstract parameters: ParametricBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type ParametricBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: func:(float -> float -> Vector3 -> unit) * slices:float * stacks:float -> ParametricBufferGeometry

[<AllowNullLiteral>]
type ParametricGeometry =
    inherit Geometry
    abstract parameters: ParametricBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type ParametricGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: func:(float -> float -> Vector3 -> unit) * slices:float * stacks:float -> ParametricGeometry

[<AllowNullLiteral>]
type ParametricBufferGeometryParameters =
    abstract func: (float -> float -> Vector3 -> unit) with get, set
    abstract slices: float with get, set
    abstract stacks: float with get, set





[<AllowNullLiteral>]
type PlaneBufferGeometry =
    inherit BufferGeometry
    abstract parameters: PlaneBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type PlaneBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?width:float * ?height:float * ?widthSegments:float * ?heightSegments:float -> PlaneBufferGeometry

[<AllowNullLiteral>]
type PlaneGeometry =
    inherit Geometry
    abstract parameters: PlaneBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type PlaneGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?width:float * ?height:float * ?widthSegments:float * ?heightSegments:float -> PlaneGeometry

[<AllowNullLiteral>]
type PlaneBufferGeometryParameters =
    abstract width: float with get, set
    abstract height: float with get, set
    abstract widthSegments: float with get, set
    abstract heightSegments: float with get, set






[<AllowNullLiteral>]
type PolyhedronBufferGeometry =
    inherit BufferGeometry
    abstract parameters: PolyhedronBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type PolyhedronBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: vertices:ResizeArray<float>
                     * indices:ResizeArray<float>
                     * ?radius:float
                     * ?detail:float
                     -> PolyhedronBufferGeometry

[<AllowNullLiteral>]
type PolyhedronGeometry =
    inherit Geometry
    abstract parameters: PolyhedronBufferGeometryParameters with get, set
    /// Bounding sphere.
    abstract boundingSphere: Sphere with get, set

[<AllowNullLiteral>]
type PolyhedronGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: vertices:ResizeArray<float>
                     * indices:ResizeArray<float>
                     * ?radius:float
                     * ?detail:float
                     -> PolyhedronGeometry

[<AllowNullLiteral>]
type PolyhedronBufferGeometryParameters =
    abstract vertices: ResizeArray<float> with get, set
    abstract indices: ResizeArray<float> with get, set
    abstract radius: float with get, set
    abstract detail: float with get, set





[<AllowNullLiteral>]
type RingBufferGeometry =
    inherit BufferGeometry
    abstract parameters: RingBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type RingBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?innerRadius:float
                     * ?outerRadius:float
                     * ?thetaSegments:float
                     * ?phiSegments:float
                     * ?thetaStart:float
                     * ?thetaLength:float
                     -> RingBufferGeometry

[<AllowNullLiteral>]
type RingGeometry =
    inherit Geometry
    abstract parameters: RingBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type RingGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?innerRadius:float
                     * ?outerRadius:float
                     * ?thetaSegments:float
                     * ?phiSegments:float
                     * ?thetaStart:float
                     * ?thetaLength:float
                     -> RingGeometry

[<AllowNullLiteral>]
type RingBufferGeometryParameters =
    abstract innerRadius: float with get, set
    abstract outerRadius: float with get, set
    abstract thetaSegments: float with get, set
    abstract phiSegments: float with get, set
    abstract thetaStart: float with get, set
    abstract thetaLength: float with get, set


type Shape = obj



[<AllowNullLiteral>]
type ShapeBufferGeometry =
    inherit BufferGeometry

[<AllowNullLiteral>]
type ShapeBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: shapes:U2<Shape, ResizeArray<Shape>> * ?curveSegments:float -> ShapeBufferGeometry

[<AllowNullLiteral>]
type ShapeGeometry =
    inherit Geometry
    abstract addShapeList: shapes:ResizeArray<Shape> * options:obj -> ShapeGeometry
    abstract addShape: shape:Shape * ?options:obj -> unit

[<AllowNullLiteral>]
type ShapeGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: shapes:U2<Shape, ResizeArray<Shape>> * ?curveSegments:float -> ShapeGeometry





[<AllowNullLiteral>]
type SphereBufferGeometry =
    inherit BufferGeometry
    abstract parameters: SphereBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type SphereBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float
                     * ?widthSegments:float
                     * ?heightSegments:float
                     * ?phiStart:float
                     * ?phiLength:float
                     * ?thetaStart:float
                     * ?thetaLength:float
                     -> SphereBufferGeometry

/// A class for generating sphere geometries
[<AllowNullLiteral>]
type SphereGeometry =
    inherit Geometry
    abstract parameters: SphereBufferGeometryParameters with get, set

/// A class for generating sphere geometries
[<AllowNullLiteral>]
type SphereGeometryStatic =
    /// <summary>The geometry is created by sweeping and calculating vertexes around the Y axis (horizontal sweep) and the Z axis (vertical sweep). Thus, incomplete spheres (akin to 'sphere slices') can be created through the use of different values of phiStart, phiLength, thetaStart and thetaLength, in order to define the points in which we start (or end) calculating those vertices.</summary>
    /// <param name="radius">— sphere radius. Default is 50.</param>
    /// <param name="widthSegments">— number of horizontal segments. Minimum value is 3, and the default is 8.</param>
    /// <param name="heightSegments">— number of vertical segments. Minimum value is 2, and the default is 6.</param>
    /// <param name="phiStart">— specify horizontal starting angle. Default is 0.</param>
    /// <param name="phiLength">— specify horizontal sweep angle size. Default is Math.PI * 2.</param>
    /// <param name="thetaStart">— specify vertical starting angle. Default is 0.</param>
    /// <param name="thetaLength">— specify vertical sweep angle size. Default is Math.PI.</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float
                     * ?widthSegments:float
                     * ?heightSegments:float
                     * ?phiStart:float
                     * ?phiLength:float
                     * ?thetaStart:float
                     * ?thetaLength:float
                     -> SphereGeometry

[<AllowNullLiteral>]
type SphereBufferGeometryParameters =
    abstract radius: float with get, set
    abstract widthSegments: float with get, set
    abstract heightSegments: float with get, set
    abstract phiStart: float with get, set
    abstract phiLength: float with get, set
    abstract thetaStart: float with get, set
    abstract thetaLength: float with get, set





[<AllowNullLiteral>]
type TetrahedronBufferGeometry =
    inherit PolyhedronBufferGeometry

[<AllowNullLiteral>]
type TetrahedronBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?detail:float -> TetrahedronBufferGeometry

[<AllowNullLiteral>]
type TetrahedronGeometry =
    inherit PolyhedronGeometry

[<AllowNullLiteral>]
type TetrahedronGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?detail:float -> TetrahedronGeometry






[<AllowNullLiteral>]
type TextGeometryParameters =
    abstract font: Font with get, set
    abstract size: float with get, set
    abstract height: float with get, set
    abstract curveSegments: float with get, set
    abstract bevelEnabled: bool with get, set
    abstract bevelThickness: float with get, set
    abstract bevelSize: float with get, set
    abstract bevelOffset: float with get, set
    abstract bevelSegments: float with get, set

[<AllowNullLiteral>]
type TextBufferGeometry =
    inherit ExtrudeBufferGeometry
    abstract parameters: TextBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type TextBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: text:string * parameters:TextGeometryParameters -> TextBufferGeometry

[<AllowNullLiteral>]
type TextGeometry =
    inherit ExtrudeGeometry
    abstract parameters: TextBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type TextGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: text:string * parameters:TextGeometryParameters -> TextGeometry

type Font = obj

[<AllowNullLiteral>]
type TextBufferGeometryParameters =
    abstract font: Font with get, set
    abstract size: float with get, set
    abstract height: float with get, set
    abstract curveSegments: float with get, set
    abstract bevelEnabled: bool with get, set
    abstract bevelThickness: float with get, set
    abstract bevelSize: float with get, set
    abstract bevelOffset: float with get, set
    abstract bevelSegments: float with get, set





[<AllowNullLiteral>]
type TorusBufferGeometry =
    inherit BufferGeometry
    abstract parameters: TorusBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type TorusBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float
                     * ?tube:float
                     * ?radialSegments:float
                     * ?tubularSegments:float
                     * ?arc:float
                     -> TorusBufferGeometry

[<AllowNullLiteral>]
type TorusGeometry =
    inherit Geometry
    abstract parameters: TorusBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type TorusGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float
                     * ?tube:float
                     * ?radialSegments:float
                     * ?tubularSegments:float
                     * ?arc:float
                     -> TorusGeometry

[<AllowNullLiteral>]
type TorusBufferGeometryParameters =
    abstract radius: float with get, set
    abstract tube: float with get, set
    abstract radialSegments: float with get, set
    abstract tubularSegments: float with get, set
    abstract arc: float with get, set





[<AllowNullLiteral>]
type TorusKnotBufferGeometry =
    inherit BufferGeometry
    abstract parameters: TorusKnotBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type TorusKnotBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float
                     * ?tube:float
                     * ?tubularSegments:float
                     * ?radialSegments:float
                     * ?p:float
                     * ?q:float
                     -> TorusKnotBufferGeometry

[<AllowNullLiteral>]
type TorusKnotGeometry =
    inherit Geometry
    abstract parameters: TorusKnotBufferGeometryParameters with get, set

[<AllowNullLiteral>]
type TorusKnotGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float
                     * ?tube:float
                     * ?tubularSegments:float
                     * ?radialSegments:float
                     * ?p:float
                     * ?q:float
                     -> TorusKnotGeometry

[<AllowNullLiteral>]
type TorusKnotBufferGeometryParameters =
    abstract radius: float with get, set
    abstract tube: float with get, set
    abstract tubularSegments: float with get, set
    abstract radialSegments: float with get, set
    abstract p: float with get, set
    abstract q: float with get, set





type Curve<'T> = Curve of 'T

[<AllowNullLiteral>]
type TubeBufferGeometry =
    inherit BufferGeometry
    abstract parameters: TubeBufferGeometryParameters with get, set
    abstract tangents: ResizeArray<Vector3> with get, set
    abstract normals: ResizeArray<Vector3> with get, set
    abstract binormals: ResizeArray<Vector3> with get, set

[<AllowNullLiteral>]
type TubeBufferGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: path:Curve<Vector3>
                     * ?tubularSegments:float
                     * ?radius:float
                     * ?radiusSegments:float
                     * ?closed:bool
                     -> TubeBufferGeometry

[<AllowNullLiteral>]
type TubeGeometry =
    inherit Geometry
    abstract parameters: TubeBufferGeometryParameters with get, set
    abstract tangents: ResizeArray<Vector3> with get, set
    abstract normals: ResizeArray<Vector3> with get, set
    abstract binormals: ResizeArray<Vector3> with get, set

[<AllowNullLiteral>]
type TubeGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: path:Curve<Vector3>
                     * ?tubularSegments:float
                     * ?radius:float
                     * ?radiusSegments:float
                     * ?closed:bool
                     -> TubeGeometry

[<AllowNullLiteral>]
type TubeBufferGeometryParameters =
    abstract path: Curve<Vector3> with get, set
    abstract tubularSegments: float with get, set
    abstract radius: float with get, set
    abstract radialSegments: float with get, set
    abstract closed: bool with get, set




[<AllowNullLiteral>]
type WireframeGeometry =
    inherit BufferGeometry

[<AllowNullLiteral>]
type WireframeGeometryStatic =
    [<Emit "new $0($1...)">]
    abstract Create: geometry:U2<Geometry, BufferGeometry> -> WireframeGeometry







[<AllowNullLiteral>]
type ArrowHelper =
    inherit Object3D
    abstract line: Line with get, set
    abstract cone: Mesh with get, set
    abstract setDirection: dir:Vector3 -> unit
    abstract setLength: length:float * ?headLength:float * ?headWidth:float -> unit
    abstract setColor: color:U3<Color, string, float> -> unit

[<AllowNullLiteral>]
type ArrowHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: dir:Vector3
                     * ?origin:Vector3
                     * ?length:float
                     * ?color:float
                     * ?headLength:float
                     * ?headWidth:float
                     -> ArrowHelper



[<AllowNullLiteral>]
type AxesHelper =
    inherit LineSegments

[<AllowNullLiteral>]
type AxesHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?size:float -> AxesHelper





[<AllowNullLiteral>]
type Box3Helper =
    inherit LineSegments
    abstract box: Box3 with get, set

[<AllowNullLiteral>]
type Box3HelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: box:Box3 * ?color:Color -> Box3Helper





[<AllowNullLiteral>]
type BoxHelper =
    inherit LineSegments
    abstract update: ?object:Object3D -> unit
    abstract setFromObject: object:Object3D -> BoxHelper

[<AllowNullLiteral>]
type BoxHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: object:Object3D * ?color:U3<Color, string, float> -> BoxHelper




[<AllowNullLiteral>]
type CameraHelper =
    inherit LineSegments
    abstract camera: Camera with get, set
    abstract pointMap: CameraHelperPointMap with get, set
    abstract update: unit -> unit

[<AllowNullLiteral>]
type CameraHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: camera:Camera -> CameraHelper

[<AllowNullLiteral>]
type CameraHelperPointMap =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: id:string -> ResizeArray<float> with get, set







[<AllowNullLiteral>]
type DirectionalLightHelper =
    inherit Object3D
    abstract light: DirectionalLight with get, set
    abstract lightPlane: Line with get, set
    abstract targetLine: Line with get, set
    abstract color: U3<Color, string, float> with get, set
    /// Local transform.
    abstract matrix: Matrix4 with get, set
    /// When this is set, it calculates the matrix of position, (rotation or quaternion) and scale every frame and also recalculates the matrixWorld property.
    abstract matrixAutoUpdate: bool with get, set
    abstract dispose: unit -> unit
    abstract update: unit -> unit

[<AllowNullLiteral>]
type DirectionalLightHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: light:DirectionalLight * ?size:float * ?color:U3<Color, string, float> -> DirectionalLightHelper




[<AllowNullLiteral>]
type GridHelper =
    inherit LineSegments
    abstract setColors: ?color1:U2<Color, float> * ?color2:U2<Color, float> -> unit

[<AllowNullLiteral>]
type GridHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: size:float * divisions:float * ?color1:U2<Color, float> * ?color2:U2<Color, float> -> GridHelper







[<AllowNullLiteral>]
type HemisphereLightHelper =
    inherit Object3D
    abstract light: HemisphereLight with get, set
    /// Local transform.
    abstract matrix: Matrix4 with get, set
    /// When this is set, it calculates the matrix of position, (rotation or quaternion) and scale every frame and also recalculates the matrixWorld property.
    abstract matrixAutoUpdate: bool with get, set
    abstract material: MeshBasicMaterial with get, set
    abstract color: U3<Color, string, float> with get, set
    abstract dispose: unit -> unit
    abstract update: unit -> unit

[<AllowNullLiteral>]
type HemisphereLightHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: light:HemisphereLight * size:float * ?color:U3<Color, float, string> -> HemisphereLightHelper




[<AllowNullLiteral>]
type PlaneHelper =
    inherit LineSegments
    abstract plane: Plane with get, set
    abstract size: float with get, set
    /// Updates global transform of the object and its children.
    abstract updateMatrixWorld: ?force:bool -> unit

[<AllowNullLiteral>]
type PlaneHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: plane:Plane * ?size:float * ?hex:float -> PlaneHelper






[<AllowNullLiteral>]
type PointLightHelper =
    inherit Object3D
    abstract light: PointLight with get, set
    abstract color: U3<Color, string, float> with get, set
    /// Local transform.
    abstract matrix: Matrix4 with get, set
    /// When this is set, it calculates the matrix of position, (rotation or quaternion) and scale every frame and also recalculates the matrixWorld property.
    abstract matrixAutoUpdate: bool with get, set
    abstract dispose: unit -> unit
    abstract update: unit -> unit

[<AllowNullLiteral>]
type PointLightHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: light:PointLight * ?sphereSize:float * ?color:U3<Color, string, float> -> PointLightHelper




[<AllowNullLiteral>]
type PolarGridHelper =
    inherit LineSegments

[<AllowNullLiteral>]
type PolarGridHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: radius:float
                     * radials:float
                     * circles:float
                     * divisions:float
                     * color1:U3<Color, string, float> option
                     * color2:U3<Color, string, float> option
                     -> PolarGridHelper





[<AllowNullLiteral>]
type SkeletonHelper =
    inherit LineSegments
    abstract bones: ResizeArray<Bone> with get, set
    abstract root: Object3D with get, set
    abstract isSkeletonHelper: obj
    abstract getBoneList: object:Object3D -> ResizeArray<Bone>
    abstract update: unit -> unit

[<AllowNullLiteral>]
type SkeletonHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: object:Object3D -> SkeletonHelper







[<AllowNullLiteral>]
type SpotLightHelper =
    inherit Object3D
    abstract light: Light with get, set
    /// Local transform.
    abstract matrix: Matrix4 with get, set
    /// When this is set, it calculates the matrix of position, (rotation or quaternion) and scale every frame and also recalculates the matrixWorld property.
    abstract matrixAutoUpdate: bool with get, set
    abstract color: U3<Color, string, float> with get, set
    abstract cone: LineSegments with get, set
    abstract dispose: unit -> unit
    abstract update: unit -> unit

[<AllowNullLiteral>]
type SpotLightHelperStatic =
    [<Emit "new $0($1...)">]
    abstract Create: light:Light * ?color:U3<Color, string, float> -> SpotLightHelper




/// This light's color gets applied to all the objects in the scene globally.
[<AllowNullLiteral>]
type AmbientLight =
    inherit Light
    /// Gets rendered into shadow map.
    abstract castShadow: bool with get, set
    abstract isAmbientLight: obj

/// This light's color gets applied to all the objects in the scene globally.
[<AllowNullLiteral>]
type AmbientLightStatic =
    /// <summary>This creates a Ambientlight with a color.</summary>
    /// <param name="color">Numeric value of the RGB component of the color or a Color instance.</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?color:U3<Color, string, float> * ?intensity:float -> AmbientLight




[<AllowNullLiteral>]
type AmbientLightProbe =
    inherit LightProbe
    abstract isAmbientLightProbe: obj

[<AllowNullLiteral>]
type AmbientLightProbeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?color:U3<Color, string, float> * ?intensity:float -> AmbientLightProbe






[<AllowNullLiteral>]
type DirectionalLight =
    inherit Light
    /// Target used for shadow camera orientation.
    abstract target: Object3D with get, set
    /// Light's intensity.
    /// Default — 1.0.
    abstract intensity: float with get, set
    abstract shadow: DirectionalLightShadow with get, set
    abstract isDirectionalLight: obj

[<AllowNullLiteral>]
type DirectionalLightStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?color:U3<Color, string, float> * ?intensity:float -> DirectionalLight




[<AllowNullLiteral>]
type DirectionalLightShadow =
    inherit LightShadow
    abstract camera: OrthographicCamera with get, set
    abstract isDirectionalLightShadow: obj

[<AllowNullLiteral>]
type DirectionalLightShadowStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> DirectionalLightShadow




[<AllowNullLiteral>]
type HemisphereLight =
    inherit Light
    abstract skyColor: Color with get, set
    abstract groundColor: Color with get, set
    abstract intensity: float with get, set
    abstract isHemisphereLight: obj

[<AllowNullLiteral>]
type HemisphereLightStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?skyColor:U3<Color, string, float>
                     * ?groundColor:U3<Color, string, float>
                     * ?intensity:float
                     -> HemisphereLight




[<AllowNullLiteral>]
type HemisphereLightProbe =
    inherit LightProbe
    abstract isHemisphereLightProbe: obj

[<AllowNullLiteral>]
type HemisphereLightProbeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?skyColor:U3<Color, string, float>
                     * ?groundColor:U3<Color, string, float>
                     * ?intensity:float
                     -> HemisphereLightProbe





/// Abstract base class for lights.
[<AllowNullLiteral>]
type Light =
    inherit Object3D
    abstract color: Color with get, set
    abstract intensity: float with get, set
    abstract isLight: obj
    /// Material gets baked in shadow receiving.
    abstract receiveShadow: bool with get, set
    abstract shadow: LightShadow with get, set
    abstract shadowCameraFov: obj with get, set
    abstract shadowCameraLeft: obj with get, set
    abstract shadowCameraRight: obj with get, set
    abstract shadowCameraTop: obj with get, set
    abstract shadowCameraBottom: obj with get, set
    abstract shadowCameraNear: obj with get, set
    abstract shadowCameraFar: obj with get, set
    abstract shadowBias: obj with get, set
    abstract shadowMapWidth: obj with get, set
    abstract shadowMapHeight: obj with get, set

/// Abstract base class for lights.
[<AllowNullLiteral>]
type LightStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?hex:U2<float, string> * ?intensity:float -> Light




[<AllowNullLiteral>]
type LightProbe =
    inherit Light
    abstract isLightProbe: obj
    abstract sh: SphericalHarmonics3 with get, set
    abstract fromJSON: json:obj -> LightProbe

[<AllowNullLiteral>]
type LightProbeStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?sh:SphericalHarmonics3 * ?intensity:float -> LightProbe








[<AllowNullLiteral>]
type LightShadow =
    abstract camera: Camera with get, set
    abstract bias: float with get, set
    abstract normalBias: float with get, set
    abstract radius: float with get, set
    abstract mapSize: Vector2 with get, set
    abstract map: RenderTarget with get, set
    abstract mapPass: RenderTarget with get, set
    abstract matrix: Matrix4 with get, set
    abstract autoUpdate: bool with get, set
    abstract needsUpdate: bool with get, set
    abstract copy: source:LightShadow -> LightShadow
    abstract clone: ?recursive:bool -> LightShadow
    abstract toJSON: unit -> obj
    abstract getFrustum: unit -> float
    abstract updateMatrices: light:Light * ?viewportIndex:float -> unit
    abstract getViewport: viewportIndex:float -> Vector4
    abstract getFrameExtents: unit -> Vector2

[<AllowNullLiteral>]
type LightShadowStatic =
    [<Emit "new $0($1...)">]
    abstract Create: camera:Camera -> LightShadow





[<AllowNullLiteral>]
type PointLight =
    inherit Light
    abstract intensity: float with get, set
    /// If non-zero, light will attenuate linearly from maximum intensity at light position down to zero at distance.
    /// Default - 0.0.
    abstract distance: float with get, set
    abstract decay: float with get, set
    abstract shadow: PointLightShadow with get, set
    abstract power: float with get, set

[<AllowNullLiteral>]
type PointLightStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?color:U3<Color, string, float> * ?intensity:float * ?distance:float * ?decay:float -> PointLight




[<AllowNullLiteral>]
type PointLightShadow =
    inherit LightShadow
    abstract camera: PerspectiveCamera with get, set

[<AllowNullLiteral>]
type PointLightShadowStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> PointLightShadow




[<AllowNullLiteral>]
type RectAreaLight =
    inherit Light
    abstract ``type``: string with get, set
    abstract width: float with get, set
    abstract height: float with get, set
    abstract intensity: float with get, set
    abstract isRectAreaLight: obj

[<AllowNullLiteral>]
type RectAreaLightStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?color:U3<Color, string, float> * ?intensity:float * ?width:float * ?height:float -> RectAreaLight






/// A point light that can cast shadow in one direction.
[<AllowNullLiteral>]
type SpotLight =
    inherit Light
    /// Spotlight focus points at target.position.
    /// Default position — (0,0,0).
    abstract target: Object3D with get, set
    /// Light's intensity.
    /// Default — 1.0.
    abstract intensity: float with get, set
    /// If non-zero, light will attenuate linearly from maximum intensity at light position down to zero at distance.
    /// Default — 0.0.
    abstract distance: float with get, set
    abstract angle: float with get, set
    abstract decay: float with get, set
    abstract shadow: SpotLightShadow with get, set
    abstract power: float with get, set
    abstract penumbra: float with get, set
    abstract isSpotLight: obj

/// A point light that can cast shadow in one direction.
[<AllowNullLiteral>]
type SpotLightStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?color:U3<Color, string, float>
                     * ?intensity:float
                     * ?distance:float
                     * ?angle:float
                     * ?penumbra:float
                     * ?decay:float
                     -> SpotLight




[<AllowNullLiteral>]
type SpotLightShadow =
    inherit LightShadow
    abstract camera: PerspectiveCamera with get, set
    abstract isSpotLightShadow: obj

[<AllowNullLiteral>]
type SpotLightShadowStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> SpotLightShadow





[<AllowNullLiteral>]
type AnimationLoader =
    inherit Loader

    abstract load: url:string
                   * onLoad:(ResizeArray<AnimationClip> -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> unit

    abstract parse: json:obj -> ResizeArray<AnimationClip>

[<AllowNullLiteral>]
type AnimationLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> AnimationLoader




[<AllowNullLiteral>]
type AudioLoader =
    inherit Loader

    abstract load: url:string
                   * onLoad:(AudioBuffer -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> unit

[<AllowNullLiteral>]
type AudioLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> AudioLoader






[<AllowNullLiteral>]
type BufferGeometryLoader =
    inherit Loader

    abstract load: url:string
                   * onLoad:(U2<InstancedBufferGeometry, BufferGeometry> -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> unit

    abstract parse: json:obj -> U2<InstancedBufferGeometry, BufferGeometry>

[<AllowNullLiteral>]
type BufferGeometryLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> BufferGeometryLoader

[<Import("Cache", "three")>]
let cache: Cache.IExports = jsNative

module Cache =

    [<AllowNullLiteral>]
    type IExports =
        abstract enabled: bool
        abstract files: obj
        abstract add: key:string * file:obj -> unit
        abstract get: key:string -> obj
        abstract remove: key:string -> unit
        abstract clear: unit -> unit





[<AllowNullLiteral>]
type CompressedTextureLoader =
    inherit Loader

    abstract load: url:string
                   * onLoad:(CompressedTexture -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> unit

[<AllowNullLiteral>]
type CompressedTextureLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> CompressedTextureLoader





[<AllowNullLiteral>]
type CubeTextureLoader =
    inherit Loader

    abstract load: urls:Array<string>
                   * ?onLoad:(CubeTexture -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> CubeTexture

[<AllowNullLiteral>]
type CubeTextureLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> CubeTextureLoader





[<AllowNullLiteral>]
type DataTextureLoader =
    inherit Loader

    abstract load: url:string
                   * onLoad:(DataTexture -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> unit

[<AllowNullLiteral>]
type DataTextureLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> DataTextureLoader


type MimeType = obj

[<AllowNullLiteral>]
type FileLoader =
    inherit Loader
    abstract mimeType: MimeType with get, set
    abstract responseType: string with get, set
    abstract withCredentials: string with get, set

    abstract load: url:string
                   * ?onLoad:(U2<string, ArrayBuffer> -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> obj

    abstract setMimeType: mimeType:MimeType -> FileLoader
    abstract setResponseType: responseType:string -> FileLoader
    abstract setWithCredentials: value:bool -> FileLoader

[<AllowNullLiteral>]
type FileLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> FileLoader





[<AllowNullLiteral>]
type FontLoader =
    inherit Loader

    abstract load: url:string
                   * ?onLoad:(Font -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> unit

    abstract parse: json:obj -> Font

[<AllowNullLiteral>]
type FontLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> FontLoader



type ImageBitmap = obj

[<AllowNullLiteral>]
type ImageBitmapLoader =
    inherit Loader
    abstract options: obj with get, set
    abstract isImageBitmapLoader: obj
    abstract setOptions: options:obj -> ImageBitmapLoader

    abstract load: url:string
                   * ?onLoad:(ImageBitmap -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> obj

[<AllowNullLiteral>]
type ImageBitmapLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> ImageBitmapLoader




/// A loader for loading an image.
/// Unlike other loaders, this one emits events instead of using predefined callbacks. So if you're interested in getting notified when things happen, you need to add listeners to the object.
[<AllowNullLiteral>]
type ImageLoader =
    inherit Loader

    abstract load: url:string
                   * ?onLoad:(HTMLImageElement -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> HTMLImageElement

/// A loader for loading an image.
/// Unlike other loaders, this one emits events instead of using predefined callbacks. So if you're interested in getting notified when things happen, you need to add listeners to the object.
[<AllowNullLiteral>]
type ImageLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> ImageLoader



/// Base class for implementing loaders.
[<AllowNullLiteral>]
type Loader =
    abstract crossOrigin: string with get, set
    abstract path: string with get, set
    abstract resourcePath: string with get, set
    abstract manager: LoadingManager with get, set
    abstract requestHeader: LoaderRequestHeader with get, set
    abstract loadAsync: url:string * ?onProgress:(ProgressEvent -> unit) -> Promise<obj>
    abstract setCrossOrigin: crossOrigin:string -> Loader
    abstract setPath: path:string -> Loader
    abstract setResourcePath: resourcePath:string -> Loader
    abstract setRequestHeader: requestHeader:LoaderSetRequestHeaderRequestHeader -> Loader

[<AllowNullLiteral>]
type LoaderSetRequestHeaderRequestHeader =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: header:string -> string with get, set

/// Base class for implementing loaders.
[<AllowNullLiteral>]
type LoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> Loader

[<AllowNullLiteral>]
type LoaderRequestHeader =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: header:string -> string with get, set



[<AllowNullLiteral>]
type LoaderUtils =
    interface
    end

[<AllowNullLiteral>]
type LoaderUtilsStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> LoaderUtils

    abstract decodeText: array:TypedArray -> string
    abstract extractUrlBase: url:string -> string

[<Import("DefaultLoadingManager", "three")>]
let DefaultLoadingManager: LoadingManager = jsNative


/// Handles and keeps track of loaded and pending data.
[<AllowNullLiteral>]
type LoadingManager =
    /// Will be called when loading of an item starts.
    abstract onStart: (string -> float -> float -> unit) with get, set
    /// Will be called when all items finish loading.
    /// The default is a function with empty body.
    abstract onLoad: (unit -> unit) with get, set
    /// Will be called for each loaded item.
    /// The default is a function with empty body.
    abstract onProgress: (string -> float -> float -> unit) with get, set
    /// Will be called when item loading fails.
    /// The default is a function with empty body.
    abstract onError: (string -> unit) with get, set
    /// <summary>If provided, the callback will be passed each resource URL before a request is sent.
    /// The callback may return the original URL, or a new URL to override loading behavior.
    /// This behavior can be used to load assets from .ZIP files, drag-and-drop APIs, and Data URIs.</summary>
    /// <param name="callback">URL modifier callback. Called with url argument, and must return resolvedURL.</param>
    abstract setURLModifier: ?callback:(string -> string) -> LoadingManager
    /// <summary>Given a URL, uses the URL modifier callback (if any) and returns a resolved URL.
    /// If no URL modifier is set, returns the original URL.</summary>
    /// <param name="url">the url to load</param>
    abstract resolveURL: url:string -> string
    abstract itemStart: url:string -> unit
    abstract itemEnd: url:string -> unit
    abstract itemError: url:string -> unit
    abstract addHandler: regex:RegExp * loader:Loader -> LoadingManager
    abstract removeHandler: regex:RegExp -> LoadingManager
    abstract getHandler: file:string -> Loader option

/// Handles and keeps track of loaded and pending data.
[<AllowNullLiteral>]
type LoadingManagerStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?onLoad:(unit -> unit)
                     * ?onProgress:(string -> float -> float -> unit)
                     * ?onError:(string -> unit)
                     -> LoadingManager






[<AllowNullLiteral>]
type MaterialLoader =
    inherit Loader
    abstract textures: MaterialLoaderTextures with get, set

    abstract load: url:string
                   * onLoad:(Material -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(U2<Error, ErrorEvent> -> unit)
                   -> unit

    abstract setTextures: textures:MaterialLoaderSetTexturesTextures -> MaterialLoader
    abstract parse: json:obj -> Material

[<AllowNullLiteral>]
type MaterialLoaderSetTexturesTextures =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: key:string -> Texture with get, set

[<AllowNullLiteral>]
type MaterialLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> MaterialLoader

[<AllowNullLiteral>]
type MaterialLoaderTextures =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: key:string -> Texture with get, set








[<AllowNullLiteral>]
type ObjectLoader =
    inherit Loader

    abstract load: url:string
                   * ?onLoad:('ObjectType -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(U2<Error, ErrorEvent> -> unit)
                   -> unit

    abstract parse: json:obj * ?onLoad:(Object3D -> unit) -> 'T
    abstract parseGeometries: json:obj -> ResizeArray<obj>
    abstract parseMaterials: json:obj * textures:ResizeArray<Texture> -> ResizeArray<Material>
    abstract parseAnimations: json:obj -> ResizeArray<AnimationClip>
    abstract parseImages: json:obj * onLoad:(unit -> unit) -> ObjectLoaderParseImagesReturn
    abstract parseTextures: json:obj * images:obj -> ResizeArray<Texture>
    abstract parseObject: data:obj * geometries:ResizeArray<obj> * materials:ResizeArray<Material> -> 'T

[<AllowNullLiteral>]
type ObjectLoaderParseImagesReturn =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: key:string -> HTMLImageElement with get, set

[<AllowNullLiteral>]
type ObjectLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> ObjectLoader





/// Class for loading a texture.
/// Unlike other loaders, this one emits events instead of using predefined callbacks. So if you're interested in getting notified when things happen, you need to add listeners to the object.
[<AllowNullLiteral>]
type TextureLoader =
    inherit Loader

    abstract load: url:string
                   * ?onLoad:(Texture -> unit)
                   * ?onProgress:(ProgressEvent -> unit)
                   * ?onError:(ErrorEvent -> unit)
                   -> Texture

/// Class for loading a texture.
/// Unlike other loaders, this one emits events instead of using predefined callbacks. So if you're interested in getting notified when things happen, you need to add listeners to the object.
[<AllowNullLiteral>]
type TextureLoaderStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?manager:LoadingManager -> TextureLoader





[<AllowNullLiteral>]
type LineBasicMaterialParameters =
    inherit MaterialParameters
    abstract color: U3<Color, string, float> with get, set
    abstract linewidth: float with get, set
    abstract linecap: string with get, set
    abstract linejoin: string with get, set
    abstract morphTargets: bool with get, set

[<AllowNullLiteral>]
type LineBasicMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract linewidth: float with get, set
    abstract linecap: string with get, set
    abstract linejoin: string with get, set
    abstract morphTargets: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:LineBasicMaterialParameters -> unit

[<AllowNullLiteral>]
type LineBasicMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:LineBasicMaterialParameters -> LineBasicMaterial




[<AllowNullLiteral>]
type LineDashedMaterialParameters =
    inherit LineBasicMaterialParameters
    abstract scale: float with get, set
    abstract dashSize: float with get, set
    abstract gapSize: float with get, set

[<AllowNullLiteral>]
type LineDashedMaterial =
    inherit LineBasicMaterial
    abstract scale: float with get, set
    abstract dashSize: float with get, set
    abstract gapSize: float with get, set
    abstract isLineDashedMaterial: obj
    /// Sets the properties based on the values.
    abstract setValues: parameters:LineDashedMaterialParameters -> unit

[<AllowNullLiteral>]
type LineDashedMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:LineDashedMaterialParameters -> LineDashedMaterial












[<Import("MaterialIdCount", "three")>]
let MaterialIdCount: float = jsNative


[<AllowNullLiteral>]
type MaterialParameters =
    abstract alphaTest: float with get, set
    abstract blendDst: BlendingDstFactor with get, set
    abstract blendDstAlpha: float with get, set
    abstract blendEquation: BlendingEquation with get, set
    abstract blendEquationAlpha: float with get, set
    abstract blending: Blending with get, set
    abstract blendSrc: U2<BlendingSrcFactor, BlendingDstFactor> with get, set
    abstract blendSrcAlpha: float with get, set
    abstract clipIntersection: bool with get, set
    abstract clippingPlanes: ResizeArray<Plane> with get, set
    abstract clipShadows: bool with get, set
    abstract colorWrite: bool with get, set
    abstract defines: obj with get, set
    abstract depthFunc: DepthModes with get, set
    abstract depthTest: bool with get, set
    abstract depthWrite: bool with get, set
    abstract fog: bool with get, set
    abstract name: string with get, set
    abstract opacity: float with get, set
    abstract polygonOffset: bool with get, set
    abstract polygonOffsetFactor: float with get, set
    abstract polygonOffsetUnits: float with get, set
    abstract precision: MaterialParametersPrecision with get, set
    abstract premultipliedAlpha: bool with get, set
    abstract dithering: bool with get, set
    abstract flatShading: bool with get, set
    abstract side: Side with get, set
    abstract shadowSide: Side with get, set
    abstract toneMapped: bool with get, set
    abstract transparent: bool with get, set
    abstract vertexColors: bool with get, set
    abstract visible: bool with get, set
    abstract stencilWrite: bool with get, set
    abstract stencilFunc: StencilFunc with get, set
    abstract stencilRef: float with get, set
    abstract stencilMask: float with get, set
    abstract stencilFail: StencilOp with get, set
    abstract stencilZFail: StencilOp with get, set
    abstract stencilZPass: StencilOp with get, set

type Shader = obj
/// Materials describe the appearance of objects. They are defined in a (mostly) renderer-independent way, so you don't have to rewrite materials if you decide to use a different renderer.
[<AllowNullLiteral>]
type Material =
    inherit EventDispatcher
    /// Sets the alpha value to be used when running an alpha test. Default is 0.
    abstract alphaTest: float with get, set
    /// Blending destination. It's one of the blending mode constants defined in Three.js. Default is {@link OneMinusSrcAlphaFactor}.
    abstract blendDst: BlendingDstFactor with get, set
    /// The tranparency of the .blendDst. Default is null.
    abstract blendDstAlpha: float with get, set
    /// Blending equation to use when applying blending. It's one of the constants defined in Three.js. Default is {@link AddEquation}.
    abstract blendEquation: BlendingEquation with get, set
    /// The tranparency of the .blendEquation. Default is null.
    abstract blendEquationAlpha: float with get, set
    /// Which blending to use when displaying objects with this material. Default is {@link NormalBlending}.
    abstract blending: Blending with get, set
    /// Blending source. It's one of the blending mode constants defined in Three.js. Default is {@link SrcAlphaFactor}.
    abstract blendSrc: U2<BlendingSrcFactor, BlendingDstFactor> with get, set
    /// The tranparency of the .blendSrc. Default is null.
    abstract blendSrcAlpha: float with get, set
    /// Changes the behavior of clipping planes so that only their intersection is clipped, rather than their union. Default is false.
    abstract clipIntersection: bool with get, set
    /// User-defined clipping planes specified as THREE.Plane objects in world space. These planes apply to the objects this material is attached to. Points in space whose signed distance to the plane is negative are clipped (not rendered). See the WebGL / clipping /intersection example. Default is null.
    abstract clippingPlanes: obj with get, set
    /// Defines whether to clip shadows according to the clipping planes specified on this material. Default is false.
    abstract clipShadows: bool with get, set
    /// Whether to render the material's color. This can be used in conjunction with a mesh's .renderOrder property to create invisible objects that occlude other objects. Default is true.
    abstract colorWrite: bool with get, set
    /// Custom defines to be injected into the shader. These are passed in form of an object literal, with key/value pairs. { MY_CUSTOM_DEFINE: '' , PI2: Math.PI * 2 }.
    /// The pairs are defined in both vertex and fragment shaders. Default is undefined.
    abstract defines: obj with get, set
    /// Which depth function to use. Default is {@link LessEqualDepth}. See the depth mode constants for all possible values.
    abstract depthFunc: DepthModes with get, set
    /// Whether to have depth test enabled when rendering this material. Default is true.
    abstract depthTest: bool with get, set
    /// Whether rendering this material has any effect on the depth buffer. Default is true.
    /// When drawing 2D overlays it can be useful to disable the depth writing in order to layer several things together without creating z-index artifacts.
    abstract depthWrite: bool with get, set
    /// Whether the material is affected by fog. Default is true.
    abstract fog: bool with get, set
    /// Unique number of this material instance.
    abstract id: float with get, set
    /// Whether rendering this material has any effect on the stencil buffer. Default is *false*.
    abstract stencilWrite: bool with get, set
    /// The stencil comparison function to use. Default is {@link AlwaysStencilFunc}. See stencil operation constants for all possible values.
    abstract stencilFunc: StencilFunc with get, set
    /// The value to use when performing stencil comparisons or stencil operations. Default is *0*.
    abstract stencilRef: float with get, set
    /// The bit mask to use when comparing against or writing to the stencil buffer. Default is *0xFF*.
    abstract stencilMask: float with get, set
    /// Which stencil operation to perform when the comparison function returns false. Default is {@link KeepStencilOp}. See the stencil operation constants for all possible values.
    abstract stencilFail: StencilOp with get, set
    /// Which stencil operation to perform when the comparison function returns true but the depth test fails. Default is {@link KeepStencilOp}. See the stencil operation constants for all possible values.
    abstract stencilZFail: StencilOp with get, set
    /// Which stencil operation to perform when the comparison function returns true and the depth test passes. Default is {@link KeepStencilOp}. See the stencil operation constants for all possible values.
    abstract stencilZPass: StencilOp with get, set
    /// Used to check whether this or derived classes are materials. Default is true.
    /// You should not change this, as it used internally for optimisation.
    abstract isMaterial: obj
    /// Material name. Default is an empty string.
    abstract name: string with get, set
    /// Specifies that the material needs to be updated, WebGL wise. Set it to true if you made changes that need to be reflected in WebGL.
    /// This property is automatically set to true when instancing a new material.
    abstract needsUpdate: bool with get, set
    /// Opacity. Default is 1.
    abstract opacity: float with get, set
    /// Whether to use polygon offset. Default is false. This corresponds to the POLYGON_OFFSET_FILL WebGL feature.
    abstract polygonOffset: bool with get, set
    /// Sets the polygon offset factor. Default is 0.
    abstract polygonOffsetFactor: float with get, set
    /// Sets the polygon offset units. Default is 0.
    abstract polygonOffsetUnits: float with get, set
    /// Override the renderer's default precision for this material. Can be "highp", "mediump" or "lowp". Defaults is null.
    abstract precision: MaterialParametersPrecision with get, set
    /// Whether to premultiply the alpha (transparency) value. See WebGL / Materials / Transparency for an example of the difference. Default is false.
    abstract premultipliedAlpha: bool with get, set
    /// Whether to apply dithering to the color to remove the appearance of banding. Default is false.
    abstract dithering: bool with get, set
    /// Define whether the material is rendered with flat shading. Default is false.
    abstract flatShading: bool with get, set
    /// Defines which of the face sides will be rendered - front, back or both.
    /// Default is THREE.FrontSide. Other options are THREE.BackSide and THREE.DoubleSide.
    abstract side: Side with get, set
    /// Defines which of the face sides will cast shadows. Default is *null*.
    /// If *null*, the value is opposite that of side, above.
    abstract shadowSide: Side with get, set
    /// Defines whether this material is tone mapped according to the renderer's toneMapping setting.
    /// Default is true.
    abstract toneMapped: bool with get, set
    /// Defines whether this material is transparent. This has an effect on rendering as transparent objects need special treatment and are rendered after non-transparent objects.
    /// When set to true, the extent to which the material is transparent is controlled by setting it's .opacity property.
    /// Default is false.
    abstract transparent: bool with get, set
    /// Value is the string 'Material'. This shouldn't be changed, and can be used to find all objects of this type in a scene.
    abstract ``type``: string with get, set
    /// UUID of this material instance. This gets automatically assigned, so this shouldn't be edited.
    abstract uuid: string with get, set
    /// Defines whether vertex coloring is used. Default is false.
    abstract vertexColors: bool with get, set
    /// Defines whether this material is visible. Default is true.
    abstract visible: bool with get, set
    /// An object that can be used to store custom data about the Material. It should not hold references to functions as these will not be cloned.
    abstract userData: obj with get, set
    /// This starts at 0 and counts how many times .needsUpdate is set to true.
    abstract version: float with get, set
    /// Return a new material with the same parameters as this material.
    abstract clone: unit -> Material
    /// Copy the parameters from the passed material into this material.
    abstract copy: material:Material -> Material
    /// This disposes the material. Textures of a material don't get disposed. These needs to be disposed by {@link Texture}.
    abstract dispose: unit -> unit
    /// <summary>An optional callback that is executed immediately before the shader program is compiled. This function is called with the shader source code as a parameter. Useful for the modification of built-in materials.</summary>
    /// <param name="shader">Source code of the shader</param>
    /// <param name="renderer">WebGLRenderer Context that is initializing the material</param>
    abstract onBeforeCompile: shader:Shader * renderer:WebGLRenderer -> unit
    /// In case onBeforeCompile is used, this callback can be used to identify values of settings used in onBeforeCompile, so three.js can reuse a cached shader or recompile the shader as needed.
    abstract customProgramCacheKey: unit -> string
    /// <summary>Sets the properties based on the values.</summary>
    /// <param name="values">A container with parameters.</param>
    abstract setValues: values:MaterialParameters -> unit
    /// <summary>Convert the material to three.js JSON format.</summary>
    /// <param name="meta">Object containing metadata such as textures or images for the material.</param>
    abstract toJSON: ?meta:obj -> obj

/// Materials describe the appearance of objects. They are defined in a (mostly) renderer-independent way, so you don't have to rewrite materials if you decide to use a different renderer.
[<AllowNullLiteral>]
type MaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Material

[<StringEnum>]
[<RequireQualifiedAccess>]
type MaterialParametersPrecision =
    | Highp
    | Mediump
    | Lowp







/// parameters is an object with one or more properties defining the material's appearance.
[<AllowNullLiteral>]
type MeshBasicMaterialParameters =
    inherit MaterialParameters
    abstract color: U3<Color, string, float> with get, set
    abstract opacity: float with get, set
    abstract map: Texture with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract specularMap: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract envMap: Texture with get, set
    abstract combine: Combine with get, set
    abstract reflectivity: float with get, set
    abstract refractionRatio: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract wireframeLinecap: string with get, set
    abstract wireframeLinejoin: string with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set

[<AllowNullLiteral>]
type MeshBasicMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract map: Texture with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract specularMap: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract envMap: Texture with get, set
    abstract combine: Combine with get, set
    abstract reflectivity: float with get, set
    abstract refractionRatio: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract wireframeLinecap: string with get, set
    abstract wireframeLinejoin: string with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshBasicMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshBasicMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshBasicMaterialParameters -> MeshBasicMaterial






[<AllowNullLiteral>]
type MeshDepthMaterialParameters =
    inherit MaterialParameters
    abstract map: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract depthPacking: DepthPackingStrategies with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set

[<AllowNullLiteral>]
type MeshDepthMaterial =
    inherit Material
    abstract map: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract depthPacking: DepthPackingStrategies with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshDepthMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshDepthMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshDepthMaterialParameters -> MeshDepthMaterial






[<AllowNullLiteral>]
type MeshDistanceMaterialParameters =
    inherit MaterialParameters
    abstract map: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract farDistance: float with get, set
    abstract nearDistance: float with get, set
    abstract referencePosition: Vector3 with get, set

[<AllowNullLiteral>]
type MeshDistanceMaterial =
    inherit Material
    abstract map: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract farDistance: float with get, set
    abstract nearDistance: float with get, set
    abstract referencePosition: Vector3 with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshDistanceMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshDistanceMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshDistanceMaterialParameters -> MeshDistanceMaterial


[<AllowNullLiteral>]
type MeshLambertMaterialParameters =
    inherit MaterialParameters
    abstract color: U3<Color, string, float> with get, set
    abstract emissive: U3<Color, string, float> with get, set
    abstract emissiveIntensity: float with get, set
    abstract emissiveMap: Texture with get, set
    abstract map: Texture with get, set
    abstract lightMap: Texture with get, set
    abstract lightMapIntensity: float with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract specularMap: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract envMap: Texture with get, set
    abstract combine: Combine with get, set
    abstract reflectivity: float with get, set
    abstract refractionRatio: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract wireframeLinecap: string with get, set
    abstract wireframeLinejoin: string with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set


[<AllowNullLiteral>]
type MeshLambertMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract emissive: Color with get, set
    abstract emissiveIntensity: float with get, set
    abstract emissiveMap: Texture with get, set
    abstract map: Texture with get, set
    abstract lightMap: Texture with get, set
    abstract lightMapIntensity: float with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract specularMap: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract envMap: Texture with get, set
    abstract combine: Combine with get, set
    abstract reflectivity: float with get, set
    abstract refractionRatio: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract wireframeLinecap: string with get, set
    abstract wireframeLinejoin: string with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshLambertMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshLambertMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshLambertMaterialParameters -> MeshLambertMaterial








[<AllowNullLiteral>]
type MeshMatcapMaterialParameters =
    inherit MaterialParameters
    abstract color: U3<Color, string, float> with get, set
    abstract matcap: Texture with get, set
    abstract map: Texture with get, set
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract alphaMap: Texture with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set

[<AllowNullLiteral>]
type MeshMatcapMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract matcap: Texture with get, set
    abstract map: Texture with get, set
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract alphaMap: Texture with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshMatcapMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshMatcapMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshMatcapMaterialParameters -> MeshMatcapMaterial







[<AllowNullLiteral>]
type MeshNormalMaterialParameters =
    inherit MaterialParameters
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set

[<AllowNullLiteral>]
type MeshNormalMaterial =
    inherit Material
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshNormalMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshNormalMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshNormalMaterialParameters -> MeshNormalMaterial









[<AllowNullLiteral>]
type MeshPhongMaterialParameters =
    inherit MaterialParameters
    /// geometry color in hexadecimal. Default is 0xffffff.
    abstract color: U3<Color, string, float> with get, set
    abstract specular: U3<Color, string, float> with get, set
    abstract shininess: float with get, set
    abstract opacity: float with get, set
    abstract map: Texture with get, set
    abstract lightMap: Texture with get, set
    abstract lightMapIntensity: float with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract emissive: U3<Color, string, float> with get, set
    abstract emissiveIntensity: float with get, set
    abstract emissiveMap: Texture with get, set
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract specularMap: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract envMap: Texture with get, set
    abstract combine: Combine with get, set
    abstract reflectivity: float with get, set
    abstract refractionRatio: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract wireframeLinecap: string with get, set
    abstract wireframeLinejoin: string with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set

[<AllowNullLiteral>]
type MeshPhongMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract specular: Color with get, set
    abstract shininess: float with get, set
    abstract map: Texture with get, set
    abstract lightMap: Texture with get, set
    abstract lightMapIntensity: float with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract emissive: Color with get, set
    abstract emissiveIntensity: float with get, set
    abstract emissiveMap: Texture with get, set
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract specularMap: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract envMap: Texture with get, set
    abstract combine: Combine with get, set
    abstract reflectivity: float with get, set
    abstract refractionRatio: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract wireframeLinecap: string with get, set
    abstract wireframeLinejoin: string with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set
    abstract metal: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshPhongMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshPhongMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshPhongMaterialParameters -> MeshPhongMaterial







[<AllowNullLiteral>]
type MeshPhysicalMaterialParameters =
    inherit MeshStandardMaterialParameters
    abstract reflectivity: float with get, set
    abstract clearcoat: float with get, set
    abstract clearcoatRoughness: float with get, set
    abstract sheen: Color with get, set
    abstract clearcoatNormalScale: Vector2 with get, set
    abstract clearcoatNormalMap: Texture with get, set

[<AllowNullLiteral>]
type MeshPhysicalMaterial =
    inherit MeshStandardMaterial
    abstract clearcoat: float with get, set
    abstract clearcoatMap: Texture with get, set
    abstract clearcoatRoughness: float with get, set
    abstract clearcoatRoughnessMap: Texture with get, set
    abstract clearcoatNormalScale: Vector2 with get, set
    abstract clearcoatNormalMap: Texture with get, set
    abstract reflectivity: float with get, set
    abstract sheen: Color with get, set
    abstract transparency: float with get, set

[<AllowNullLiteral>]
type MeshPhysicalMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: parameters:MeshPhysicalMaterialParameters -> MeshPhysicalMaterial








[<AllowNullLiteral>]
type MeshStandardMaterialParameters =
    inherit MaterialParameters
    abstract color: U3<Color, string, float> with get, set
    abstract roughness: float with get, set
    abstract metalness: float with get, set
    abstract map: Texture with get, set
    abstract lightMap: Texture with get, set
    abstract lightMapIntensity: float with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract emissive: U3<Color, string, float> with get, set
    abstract emissiveIntensity: float with get, set
    abstract emissiveMap: Texture with get, set
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract roughnessMap: Texture with get, set
    abstract metalnessMap: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract envMap: Texture with get, set
    abstract envMapIntensity: float with get, set
    abstract refractionRatio: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract skinning: bool with get, set
    abstract vertexTangents: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set

[<AllowNullLiteral>]
type MeshStandardMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract roughness: float with get, set
    abstract metalness: float with get, set
    abstract map: Texture with get, set
    abstract lightMap: Texture with get, set
    abstract lightMapIntensity: float with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract emissive: Color with get, set
    abstract emissiveIntensity: float with get, set
    abstract emissiveMap: Texture with get, set
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract roughnessMap: Texture with get, set
    abstract metalnessMap: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract envMap: Texture with get, set
    abstract envMapIntensity: float with get, set
    abstract refractionRatio: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract skinning: bool with get, set
    abstract vertexTangents: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshStandardMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshStandardMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshStandardMaterialParameters -> MeshStandardMaterial








[<AllowNullLiteral>]
type MeshToonMaterialParameters =
    inherit MaterialParameters
    /// geometry color in hexadecimal. Default is 0xffffff.
    abstract color: U3<Color, string, float> with get, set
    abstract opacity: float with get, set
    abstract gradientMap: Texture with get, set
    abstract map: Texture with get, set
    abstract lightMap: Texture with get, set
    abstract lightMapIntensity: float with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract emissive: U3<Color, string, float> with get, set
    abstract emissiveIntensity: float with get, set
    abstract emissiveMap: Texture with get, set
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract alphaMap: Texture with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract wireframeLinecap: string with get, set
    abstract wireframeLinejoin: string with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set

[<AllowNullLiteral>]
type MeshToonMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract gradientMap: Texture with get, set
    abstract map: Texture with get, set
    abstract lightMap: Texture with get, set
    abstract lightMapIntensity: float with get, set
    abstract aoMap: Texture with get, set
    abstract aoMapIntensity: float with get, set
    abstract emissive: Color with get, set
    abstract emissiveIntensity: float with get, set
    abstract emissiveMap: Texture with get, set
    abstract bumpMap: Texture with get, set
    abstract bumpScale: float with get, set
    abstract normalMap: Texture with get, set
    abstract normalMapType: NormalMapTypes with get, set
    abstract normalScale: Vector2 with get, set
    abstract displacementMap: Texture with get, set
    abstract displacementScale: float with get, set
    abstract displacementBias: float with get, set
    abstract alphaMap: Texture with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract wireframeLinecap: string with get, set
    abstract wireframeLinejoin: string with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:MeshToonMaterialParameters -> unit

[<AllowNullLiteral>]
type MeshToonMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:MeshToonMaterialParameters -> MeshToonMaterial






[<AllowNullLiteral>]
type PointsMaterialParameters =
    inherit MaterialParameters
    abstract color: U3<Color, string, float> with get, set
    abstract map: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract size: float with get, set
    abstract sizeAttenuation: bool with get, set
    abstract morphTargets: bool with get, set

[<AllowNullLiteral>]
type PointsMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract map: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract size: float with get, set
    abstract sizeAttenuation: bool with get, set
    abstract morphTargets: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:PointsMaterialParameters -> unit

[<AllowNullLiteral>]
type PointsMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:PointsMaterialParameters -> PointsMaterial




[<AllowNullLiteral>]
type RawShaderMaterial =
    inherit ShaderMaterial

[<AllowNullLiteral>]
type RawShaderMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:ShaderMaterialParameters -> RawShaderMaterial





[<AllowNullLiteral>]
type ShaderMaterialParameters =
    inherit MaterialParameters
    abstract uniforms: ShaderMaterialParametersUniforms with get, set
    abstract vertexShader: string with get, set
    abstract fragmentShader: string with get, set
    abstract linewidth: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract lights: bool with get, set
    abstract clipping: bool with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set
    abstract extensions: ShaderMaterialParametersExtensions with get, set

type IUniform = obj

[<AllowNullLiteral>]
type ShaderMaterial =
    inherit Material
    abstract uniforms: ShaderMaterialParametersUniforms with get, set
    abstract vertexShader: string with get, set
    abstract fragmentShader: string with get, set
    abstract linewidth: float with get, set
    abstract wireframe: bool with get, set
    abstract wireframeLinewidth: float with get, set
    abstract lights: bool with get, set
    abstract clipping: bool with get, set
    abstract skinning: bool with get, set
    abstract morphTargets: bool with get, set
    abstract morphNormals: bool with get, set
    abstract derivatives: obj with get, set
    abstract extensions: ShaderMaterialExtensions with get, set
    abstract defaultAttributeValues: obj with get, set
    abstract index0AttributeName: string with get, set
    abstract uniformsNeedUpdate: bool with get, set
    /// Sets the properties based on the values.
    abstract setValues: parameters:ShaderMaterialParameters -> unit
    /// Convert the material to three.js JSON format.
    abstract toJSON: meta:obj -> obj

[<AllowNullLiteral>]
type ShaderMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:ShaderMaterialParameters -> ShaderMaterial

[<AllowNullLiteral>]
type ShaderMaterialParametersUniforms =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: uniform:string -> IUniform with get, set

[<AllowNullLiteral>]
type ShaderMaterialParametersExtensions =
    abstract derivatives: bool with get, set
    abstract fragDepth: bool with get, set
    abstract drawBuffers: bool with get, set
    abstract shaderTextureLOD: bool with get, set

[<AllowNullLiteral>]
type ShaderMaterialExtensions =
    abstract derivatives: bool with get, set
    abstract fragDepth: bool with get, set
    abstract drawBuffers: bool with get, set
    abstract shaderTextureLOD: bool with get, set





[<AllowNullLiteral>]
type ShadowMaterialParameters =
    inherit MaterialParameters
    abstract color: U3<Color, string, float> with get, set

[<AllowNullLiteral>]
type ShadowMaterial =
    inherit Material
    abstract color: Color with get, set

[<AllowNullLiteral>]
type ShadowMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:ShadowMaterialParameters -> ShadowMaterial






[<AllowNullLiteral>]
type SpriteMaterialParameters =
    inherit MaterialParameters
    abstract color: U3<Color, string, float> with get, set
    abstract map: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract rotation: float with get, set
    abstract sizeAttenuation: bool with get, set

[<AllowNullLiteral>]
type SpriteMaterial =
    inherit Material
    abstract color: Color with get, set
    abstract map: Texture with get, set
    abstract alphaMap: Texture with get, set
    abstract rotation: float with get, set
    abstract sizeAttenuation: bool with get, set
    abstract isSpriteMaterial: obj
    /// Sets the properties based on the values.
    abstract setValues: parameters:SpriteMaterialParameters -> unit
    /// Copy the parameters from the passed material into this material.
    abstract copy: source:SpriteMaterial -> SpriteMaterial

[<AllowNullLiteral>]
type SpriteMaterialStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:SpriteMaterialParameters -> SpriteMaterial



[<AllowNullLiteral>]
type Box2 =
    abstract max: Vector2 with get, set
    abstract min: Vector2 with get, set
    abstract set: min:Vector2 * max:Vector2 -> Box2
    abstract setFromPoints: points:ResizeArray<Vector2> -> Box2
    abstract setFromCenterAndSize: center:Vector2 * size:Vector2 -> Box2
    abstract clone: unit -> Box2
    abstract copy: box:Box2 -> Box2
    abstract makeEmpty: unit -> Box2
    abstract isEmpty: unit -> bool
    abstract getCenter: target:Vector2 -> Vector2
    abstract getSize: target:Vector2 -> Vector2
    abstract expandByPoint: point:Vector2 -> Box2
    abstract expandByVector: vector:Vector2 -> Box2
    abstract expandByScalar: scalar:float -> Box2
    abstract containsPoint: point:Vector2 -> bool
    abstract containsBox: box:Box2 -> bool
    abstract getParameter: point:Vector2 * target:Vector2 -> Vector2
    abstract intersectsBox: box:Box2 -> bool
    abstract clampPoint: point:Vector2 * target:Vector2 -> Vector2
    abstract distanceToPoint: point:Vector2 -> float
    abstract intersect: box:Box2 -> Box2
    abstract union: box:Box2 -> Box2
    abstract translate: offset:Vector2 -> Box2
    abstract equals: box:Box2 -> bool
    abstract empty: unit -> obj
    abstract isIntersectionBox: b:obj -> obj

[<AllowNullLiteral>]
type Box2Static =
    [<Emit "new $0($1...)">]
    abstract Create: ?min:Vector2 * ?max:Vector2 -> Box2









[<AllowNullLiteral>]
type Box3 =
    abstract max: Vector3 with get, set
    abstract min: Vector3 with get, set
    abstract isBox3: obj
    abstract set: min:Vector3 * max:Vector3 -> Box3
    abstract setFromArray: array:ArrayLike<float> -> Box3
    abstract setFromBufferAttribute: bufferAttribute:BufferAttribute -> Box3
    abstract setFromPoints: points:ResizeArray<Vector3> -> Box3
    abstract setFromCenterAndSize: center:Vector3 * size:Vector3 -> Box3
    abstract setFromObject: object:Object3D -> Box3
    abstract clone: unit -> Box3
    abstract copy: box:Box3 -> Box3
    abstract makeEmpty: unit -> Box3
    abstract isEmpty: unit -> bool
    abstract getCenter: target:Vector3 -> Vector3
    abstract getSize: target:Vector3 -> Vector3
    abstract expandByPoint: point:Vector3 -> Box3
    abstract expandByVector: vector:Vector3 -> Box3
    abstract expandByScalar: scalar:float -> Box3
    abstract expandByObject: object:Object3D -> Box3
    abstract containsPoint: point:Vector3 -> bool
    abstract containsBox: box:Box3 -> bool
    abstract getParameter: point:Vector3 * target:Vector3 -> Vector3
    abstract intersectsBox: box:Box3 -> bool
    abstract intersectsSphere: sphere:Sphere -> bool
    abstract intersectsPlane: plane:Plane -> bool
    abstract intersectsTriangle: triangle:Triangle -> bool
    abstract clampPoint: point:Vector3 * target:Vector3 -> Vector3
    abstract distanceToPoint: point:Vector3 -> float
    abstract getBoundingSphere: target:Sphere -> Sphere
    abstract intersect: box:Box3 -> Box3
    abstract union: box:Box3 -> Box3
    abstract applyMatrix4: matrix:Matrix4 -> Box3
    abstract translate: offset:Vector3 -> Box3
    abstract equals: box:Box3 -> bool
    abstract empty: unit -> obj
    abstract isIntersectionBox: b:obj -> obj
    abstract isIntersectionSphere: s:obj -> obj

[<AllowNullLiteral>]
type Box3Static =
    [<Emit "new $0($1...)">]
    abstract Create: ?min:Vector3 * ?max:Vector3 -> Box3



[<AllowNullLiteral>]
type HSL =
    abstract h: float with get, set
    abstract s: float with get, set
    abstract l: float with get, set

type Record<'T, 'K> = Record of 'T * 'K
/// Represents a color. See also {@link ColorUtils}.
[<AllowNullLiteral>]
type Color =
    abstract isColor: obj
    /// Red channel value between 0 and 1. Default is 1.
    abstract r: float with get, set
    /// Green channel value between 0 and 1. Default is 1.
    abstract g: float with get, set
    /// Blue channel value between 0 and 1. Default is 1.
    abstract b: float with get, set
    abstract set: color:U3<Color, string, float> -> Color
    abstract setScalar: scalar:float -> Color
    abstract setHex: hex:float -> Color
    /// <summary>Sets this color from RGB values.</summary>
    /// <param name="r">Red channel value between 0 and 1.</param>
    /// <param name="g">Green channel value between 0 and 1.</param>
    /// <param name="b">Blue channel value between 0 and 1.</param>
    abstract setRGB: r:float * g:float * b:float -> Color
    /// <summary>Sets this color from HSL values.
    /// Based on MochiKit implementation by Bob Ippolito.</summary>
    /// <param name="h">Hue channel value between 0 and 1.</param>
    /// <param name="s">Saturation value channel between 0 and 1.</param>
    /// <param name="l">Value channel value between 0 and 1.</param>
    abstract setHSL: h:float * s:float * l:float -> Color
    /// Sets this color from a CSS context style string.
    abstract setStyle: style:string -> Color
    /// <summary>Sets this color from a color name.
    /// Faster than {@link Color#setStyle .setStyle()} method if you don't need the other CSS-style formats.</summary>
    /// <param name="style">Color name in X11 format.</param>
    abstract setColorName: style:string -> Color
    /// Clones this color.
    abstract clone: unit -> Color
    /// <summary>Copies given color.</summary>
    /// <param name="color">Color to copy.</param>
    abstract copy: color:Color -> Color
    /// <summary>Copies given color making conversion from gamma to linear space.</summary>
    /// <param name="color">Color to copy.</param>
    abstract copyGammaToLinear: color:Color * ?gammaFactor:float -> Color
    /// <summary>Copies given color making conversion from linear to gamma space.</summary>
    /// <param name="color">Color to copy.</param>
    abstract copyLinearToGamma: color:Color * ?gammaFactor:float -> Color
    /// Converts this color from gamma to linear space.
    abstract convertGammaToLinear: ?gammaFactor:float -> Color
    /// Converts this color from linear to gamma space.
    abstract convertLinearToGamma: ?gammaFactor:float -> Color
    /// <summary>Copies given color making conversion from sRGB to linear space.</summary>
    /// <param name="color">Color to copy.</param>
    abstract copySRGBToLinear: color:Color -> Color
    /// <summary>Copies given color making conversion from linear to sRGB space.</summary>
    /// <param name="color">Color to copy.</param>
    abstract copyLinearToSRGB: color:Color -> Color
    /// Converts this color from sRGB to linear space.
    abstract convertSRGBToLinear: unit -> Color
    /// Converts this color from linear to sRGB space.
    abstract convertLinearToSRGB: unit -> Color
    /// Returns the hexadecimal value of this color.
    abstract getHex: unit -> float
    /// Returns the string formated hexadecimal value of this color.
    abstract getHexString: unit -> string
    abstract getHSL: target:HSL -> HSL
    /// Returns the value of this color in CSS context style.
    /// Example: rgb(r, g, b)
    abstract getStyle: unit -> string
    abstract offsetHSL: h:float * s:float * l:float -> Color
    abstract add: color:Color -> Color
    abstract addColors: color1:Color * color2:Color -> Color
    abstract addScalar: s:float -> Color
    abstract sub: color:Color -> Color
    abstract multiply: color:Color -> Color
    abstract multiplyScalar: s:float -> Color
    abstract lerp: color:Color * alpha:float -> Color
    abstract lerpHSL: color:Color * alpha:float -> Color
    abstract equals: color:Color -> bool
    /// <summary>Sets this color's red, green and blue value from the provided array.</summary>
    /// <param name="array">the source array.</param>
    /// <param name="offset">(optional) offset into the array. Default is 0.</param>
    abstract fromArray: array:ResizeArray<float> * ?offset:float -> Color
    /// <summary>Sets this color's red, green and blue value from the provided array-like.</summary>
    /// <param name="array">the source array-like.</param>
    /// <param name="offset">(optional) offset into the array-like. Default is 0.</param>
    abstract fromArray: array:ArrayLike<float> * ?offset:float -> Color
    /// <summary>Returns an array [red, green, blue], or copies red, green and blue into the provided array.</summary>
    /// <param name="array">(optional) array to store the color to. If this is not provided, a new array will be created.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    /// <summary>Copies red, green and blue into the provided array-like.</summary>
    /// <param name="offset">(optional) optional offset into the array-like.</param>
    abstract toArray: xyz:ArrayLike<float> * ?offset:float -> ArrayLike<float>
    abstract fromBufferAttribute: attribute:BufferAttribute * index:float -> Color

/// Represents a color. See also {@link ColorUtils}.
[<AllowNullLiteral>]
type ColorStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?color:U3<Color, string, float> -> Color

    [<Emit "new $0($1...)">]
    abstract Create: r:float * g:float * b:float -> Color
    /// List of X11 color names.
    abstract NAMES: Record<string, float> with get, set



[<AllowNullLiteral>]
type Cylindrical =
    abstract radius: float with get, set
    abstract theta: float with get, set
    abstract y: float with get, set
    abstract clone: unit -> Cylindrical
    abstract copy: other:Cylindrical -> Cylindrical
    abstract set: radius:float * theta:float * y:float -> Cylindrical
    abstract setFromVector3: vec3:Vector3 -> Cylindrical
    abstract setFromCartesianCoords: x:float * y:float * z:float -> Cylindrical

[<AllowNullLiteral>]
type CylindricalStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?theta:float * ?y:float -> Cylindrical





[<AllowNullLiteral>]
type Euler =
    abstract x: float with get, set
    abstract y: float with get, set
    abstract z: float with get, set
    abstract order: string with get, set
    abstract isEuler: obj
    abstract _onChangeCallback: Function with get, set
    abstract set: x:float * y:float * z:float * ?order:string -> Euler
    abstract clone: unit -> Euler
    abstract copy: euler:Euler -> Euler
    abstract setFromRotationMatrix: m:Matrix4 * ?order:string -> Euler
    abstract setFromQuaternion: q:Quaternion * ?order:string -> Euler
    abstract setFromVector3: v:Vector3 * ?order:string -> Euler
    abstract reorder: newOrder:string -> Euler
    abstract equals: euler:Euler -> bool
    abstract fromArray: xyzo:ResizeArray<obj> -> Euler
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    abstract toVector3: ?optionalResult:Vector3 -> Vector3
    abstract _onChange: callback:Function -> Euler

[<AllowNullLiteral>]
type EulerStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?x:float * ?y:float * ?z:float * ?order:string -> Euler

    abstract RotationOrders: ResizeArray<string> with get, set
    abstract DefaultOrder: string with get, set









/// Frustums are used to determine what is inside the camera's field of view. They help speed up the rendering process.
[<AllowNullLiteral>]
type Frustum =
    /// Array of 6 vectors.
    abstract planes: ResizeArray<Plane> with get, set
    abstract set: p0:Plane * p1:Plane * p2:Plane * p3:Plane * p4:Plane * p5:Plane -> Frustum
    abstract clone: unit -> Frustum
    abstract copy: frustum:Frustum -> Frustum
    abstract setFromProjectionMatrix: m:Matrix4 -> Frustum
    abstract intersectsObject: object:Object3D -> bool
    abstract intersectsSprite: sprite:Sprite -> bool
    abstract intersectsSphere: sphere:Sphere -> bool
    abstract intersectsBox: box:Box3 -> bool
    abstract containsPoint: point:Vector3 -> bool

/// Frustums are used to determine what is inside the camera's field of view. They help speed up the rendering process.
[<AllowNullLiteral>]
type FrustumStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?p0:Plane * ?p1:Plane * ?p2:Plane * ?p3:Plane * ?p4:Plane * ?p5:Plane -> Frustum


[<AllowNullLiteral>]
type Interpolant =
    abstract parameterPositions: obj with get, set
    abstract sampleValues: obj with get, set
    abstract valueSize: float with get, set
    abstract resultBuffer: obj with get, set
    abstract evaluate: time:float -> obj

[<AllowNullLiteral>]
type InterpolantStatic =
    [<Emit "new $0($1...)">]
    abstract Create: parameterPositions:obj
                     * sampleValues:obj
                     * sampleSize:float
                     * ?resultBuffer:obj
                     -> Interpolant




[<AllowNullLiteral>]
type Line3 =
    abstract start: Vector3 with get, set
    abstract ``end``: Vector3 with get, set
    abstract set: ?start:Vector3 * ?``end``:Vector3 -> Line3
    abstract clone: unit -> Line3
    abstract copy: line:Line3 -> Line3
    abstract getCenter: target:Vector3 -> Vector3
    abstract delta: target:Vector3 -> Vector3
    abstract distanceSq: unit -> float
    abstract distance: unit -> float
    abstract at: t:float * target:Vector3 -> Vector3
    abstract closestPointToPointParameter: point:Vector3 * ?clampToLine:bool -> float
    abstract closestPointToPoint: point:Vector3 * clampToLine:bool * target:Vector3 -> Vector3
    abstract applyMatrix4: matrix:Matrix4 -> Line3
    abstract equals: line:Line3 -> bool

[<AllowNullLiteral>]
type Line3Static =
    [<Emit "new $0($1...)">]
    abstract Create: ?start:Vector3 * ?``end``:Vector3 -> Line3

[<Import("MathUtils", "three")>]
let mathUtils: MathUtils.IExports = jsNative

module MathUtils =

    [<AllowNullLiteral>]
    type IExports =
        abstract DEG2RAD: float
        abstract RAD2DEG: float
        abstract generateUUID: unit -> string
        /// <summary>Clamps the x to be between a and b.</summary>
        /// <param name="value">Value to be clamped.</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value.</param>
        abstract clamp: value:float * min:float * max:float -> float
        abstract euclideanModulo: n:float * m:float -> float
        /// <summary>Linear mapping of x from range [a1, a2] to range [b1, b2].</summary>
        /// <param name="x">Value to be mapped.</param>
        /// <param name="a1">Minimum value for range A.</param>
        /// <param name="a2">Maximum value for range A.</param>
        /// <param name="b1">Minimum value for range B.</param>
        /// <param name="b2">Maximum value for range B.</param>
        abstract mapLinear: x:float * a1:float * a2:float * b1:float * b2:float -> float
        abstract smoothstep: x:float * min:float * max:float -> float
        abstract smootherstep: x:float * min:float * max:float -> float
        /// Random float from 0 to 1 with 16 bits of randomness.
        /// Standard Math.random() creates repetitive patterns when applied over larger space.
        abstract random16: unit -> float
        /// Random integer from low to high interval.
        abstract randInt: low:float * high:float -> float
        /// Random float from low to high interval.
        abstract randFloat: low:float * high:float -> float
        /// Random float from - range / 2 to range / 2 interval.
        abstract randFloatSpread: range:float -> float
        abstract degToRad: degrees:float -> float
        abstract radToDeg: radians:float -> float
        abstract isPowerOfTwo: value:float -> bool
        /// <summary>Returns a value linearly interpolated from two known points based
        /// on the given interval - t = 0 will return x and t = 1 will return y.</summary>
        /// <param name="x">Start point.</param>
        /// <param name="y">End point.</param>
        /// <param name="t">interpolation factor in the closed interval [0, 1]</param>
        abstract lerp: x:float * y:float * t:float -> float
        abstract nearestPowerOfTwo: value:float -> float
        abstract nextPowerOfTwo: value:float -> float
        abstract floorPowerOfTwo: value:float -> float
        abstract ceilPowerOfTwo: value:float -> float
        abstract setQuaternionFromProperEuler: q:Quaternion * a:float * b:float * c:float * order:string -> unit




/// ( interface Matrix<T> )
[<AllowNullLiteral>]
type Matrix =
    /// Array with matrix values.
    abstract elements: ResizeArray<float> with get, set
    /// identity():T;
    abstract identity: unit -> Matrix
    /// copy(m:T):T;
    abstract copy: m:Matrix -> Matrix
    /// multiplyScalar(s:number):T;
    abstract multiplyScalar: s:float -> Matrix
    abstract determinant: unit -> float
    /// getInverse(matrix:T):T;
    abstract getInverse: matrix:Matrix -> Matrix
    /// transpose():T;
    abstract transpose: unit -> Matrix
    /// clone():T;
    abstract clone: unit -> Matrix

/// ( class Matrix3 implements Matrix<Matrix3> )
[<AllowNullLiteral>]
type Matrix3 =
    inherit Matrix
    /// Array with matrix values.
    abstract elements: ResizeArray<float> with get, set

    abstract set: n11:float
                  * n12:float
                  * n13:float
                  * n21:float
                  * n22:float
                  * n23:float
                  * n31:float
                  * n32:float
                  * n33:float
                  -> Matrix3
    /// identity():T;
    abstract identity: unit -> Matrix3
    /// clone():T;
    abstract clone: unit -> Matrix3
    /// copy(m:T):T;
    abstract copy: m:Matrix3 -> Matrix3
    abstract extractBasis: xAxis:Vector3 * yAxis:Vector3 * zAxis:Vector3 -> Matrix3
    abstract setFromMatrix4: m:Matrix4 -> Matrix3
    /// multiplyScalar(s:number):T;
    abstract multiplyScalar: s:float -> Matrix3
    abstract determinant: unit -> float
    /// getInverse(matrix:T):T;
    abstract getInverse: matrix:Matrix3 -> Matrix3
    /// Transposes this matrix in place.
    abstract transpose: unit -> Matrix3
    abstract getNormalMatrix: matrix4:Matrix4 -> Matrix3
    /// Transposes this matrix into the supplied array r, and returns itself.
    abstract transposeIntoArray: r:ResizeArray<float> -> Matrix3
    abstract setUvTransform: tx:float * ty:float * sx:float * sy:float * rotation:float * cx:float * cy:float -> Matrix3
    abstract scale: sx:float * sy:float -> Matrix3
    abstract rotate: theta:float -> Matrix3
    abstract translate: tx:float * ty:float -> Matrix3
    abstract equals: matrix:Matrix3 -> bool
    /// <summary>Sets the values of this matrix from the provided array.</summary>
    /// <param name="array">the source array.</param>
    /// <param name="offset">(optional) offset into the array. Default is 0.</param>
    abstract fromArray: array:ResizeArray<float> * ?offset:float -> Matrix3
    /// <summary>Sets the values of this matrix from the provided array-like.</summary>
    /// <param name="array">the source array-like.</param>
    /// <param name="offset">(optional) offset into the array-like. Default is 0.</param>
    abstract fromArray: array:ArrayLike<float> * ?offset:float -> Matrix3
    /// <summary>Returns an array with the values of this matrix, or copies them into the provided array.</summary>
    /// <param name="array">(optional) array to store the matrix to. If this is not provided, a new array will be created.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    /// <summary>Copies he values of this matrix into the provided array-like.</summary>
    /// <param name="array">array-like to store the matrix to.</param>
    /// <param name="offset">(optional) optional offset into the array-like.</param>
    abstract toArray: ?array:ArrayLike<float> * ?offset:float -> ArrayLike<float>
    /// Multiplies this matrix by m.
    abstract multiply: m:Matrix3 -> Matrix3
    abstract premultiply: m:Matrix3 -> Matrix3
    /// Sets this matrix to a x b.
    abstract multiplyMatrices: a:Matrix3 * b:Matrix3 -> Matrix3
    abstract multiplyVector3: vector:Vector3 -> obj
    abstract multiplyVector3Array: a:obj -> obj
    /// getInverse(matrix:T):T;
    abstract getInverse: matrix:Matrix4 * ?throwOnDegenerate:bool -> Matrix3
    abstract flattenToArrayOffset: array:ResizeArray<float> * offset:float -> ResizeArray<float>

/// ( class Matrix3 implements Matrix<Matrix3> )
[<AllowNullLiteral>]
type Matrix3Static =
    /// Creates an identity matrix.
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Matrix3






/// A 4x4 Matrix.
[<AllowNullLiteral>]
type Matrix4 =
    inherit Matrix
    /// Array with matrix values.
    abstract elements: ResizeArray<float> with get, set
    /// Sets all fields of this matrix.
    abstract set: n11:float
                  * n12:float
                  * n13:float
                  * n14:float
                  * n21:float
                  * n22:float
                  * n23:float
                  * n24:float
                  * n31:float
                  * n32:float
                  * n33:float
                  * n34:float
                  * n41:float
                  * n42:float
                  * n43:float
                  * n44:float
                  -> Matrix4
    /// Resets this matrix to identity.
    abstract identity: unit -> Matrix4
    /// clone():T;
    abstract clone: unit -> Matrix4
    /// copy(m:T):T;
    abstract copy: m:Matrix4 -> Matrix4
    abstract copyPosition: m:Matrix4 -> Matrix4
    abstract extractBasis: xAxis:Vector3 * yAxis:Vector3 * zAxis:Vector3 -> Matrix4
    abstract makeBasis: xAxis:Vector3 * yAxis:Vector3 * zAxis:Vector3 -> Matrix4
    /// Copies the rotation component of the supplied matrix m into this matrix rotation component.
    abstract extractRotation: m:Matrix4 -> Matrix4
    abstract makeRotationFromEuler: euler:Euler -> Matrix4
    abstract makeRotationFromQuaternion: q:Quaternion -> Matrix4
    /// Constructs a rotation matrix, looking from eye towards center with defined up vector.
    abstract lookAt: eye:Vector3 * target:Vector3 * up:Vector3 -> Matrix4
    /// Multiplies this matrix by m.
    abstract multiply: m:Matrix4 -> Matrix4
    abstract premultiply: m:Matrix4 -> Matrix4
    /// Sets this matrix to a x b.
    abstract multiplyMatrices: a:Matrix4 * b:Matrix4 -> Matrix4
    /// Sets this matrix to a x b and stores the result into the flat array r.
    /// r can be either a regular Array or a TypedArray.
    abstract multiplyToArray: a:Matrix4 * b:Matrix4 * r:ResizeArray<float> -> Matrix4
    /// Multiplies this matrix by s.
    abstract multiplyScalar: s:float -> Matrix4
    /// Computes determinant of this matrix.
    /// Based on http://www.euclideanspace.com/maths/algebra/matrix/functions/inverse/fourD/index.htm
    abstract determinant: unit -> float
    /// Transposes this matrix.
    abstract transpose: unit -> Matrix4
    /// Sets the position component for this matrix from vector v.
    abstract setPosition: v:U2<Vector3, float> * ?y:float * ?z:float -> Matrix4
    /// Sets this matrix to the inverse of matrix m.
    /// Based on http://www.euclideanspace.com/maths/algebra/matrix/functions/inverse/fourD/index.htm.
    abstract getInverse: m:Matrix4 -> Matrix4
    /// Multiplies the columns of this matrix by vector v.
    abstract scale: v:Vector3 -> Matrix4
    abstract getMaxScaleOnAxis: unit -> float
    /// Sets this matrix as translation transform.
    abstract makeTranslation: x:float * y:float * z:float -> Matrix4
    /// <summary>Sets this matrix as rotation transform around x axis by theta radians.</summary>
    /// <param name="theta">Rotation angle in radians.</param>
    abstract makeRotationX: theta:float -> Matrix4
    /// <summary>Sets this matrix as rotation transform around y axis by theta radians.</summary>
    /// <param name="theta">Rotation angle in radians.</param>
    abstract makeRotationY: theta:float -> Matrix4
    /// <summary>Sets this matrix as rotation transform around z axis by theta radians.</summary>
    /// <param name="theta">Rotation angle in radians.</param>
    abstract makeRotationZ: theta:float -> Matrix4
    /// <summary>Sets this matrix as rotation transform around axis by angle radians.
    /// Based on http://www.gamedev.net/reference/articles/article1199.asp.</summary>
    /// <param name="axis">Rotation axis.</param>
    abstract makeRotationAxis: axis:Vector3 * angle:float -> Matrix4
    /// Sets this matrix as scale transform.
    abstract makeScale: x:float * y:float * z:float -> Matrix4
    /// Sets this matrix to the transformation composed of translation, rotation and scale.
    abstract compose: translation:Vector3 * rotation:Quaternion * scale:Vector3 -> Matrix4
    /// Decomposes this matrix into it's position, quaternion and scale components.
    abstract decompose: translation:Vector3 * rotation:Quaternion * scale:Vector3 -> Matrix4
    /// Creates a frustum matrix.
    abstract makePerspective: left:float * right:float * bottom:float * top:float * near:float * far:float -> Matrix4
    /// Creates a perspective projection matrix.
    abstract makePerspective: fov:float * aspect:float * near:float * far:float -> Matrix4
    /// Creates an orthographic projection matrix.
    abstract makeOrthographic: left:float * right:float * top:float * bottom:float * near:float * far:float -> Matrix4
    abstract equals: matrix:Matrix4 -> bool
    /// <summary>Sets the values of this matrix from the provided array.</summary>
    /// <param name="array">the source array.</param>
    /// <param name="offset">(optional) offset into the array. Default is 0.</param>
    abstract fromArray: array:ResizeArray<float> * ?offset:float -> Matrix4
    /// <summary>Sets the values of this matrix from the provided array-like.</summary>
    /// <param name="array">the source array-like.</param>
    /// <param name="offset">(optional) offset into the array-like. Default is 0.</param>
    abstract fromArray: array:ArrayLike<float> * ?offset:float -> Matrix4
    /// <summary>Returns an array with the values of this matrix, or copies them into the provided array.</summary>
    /// <param name="array">(optional) array to store the matrix to. If this is not provided, a new array will be created.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    /// <summary>Copies he values of this matrix into the provided array-like.</summary>
    /// <param name="array">array-like to store the matrix to.</param>
    /// <param name="offset">(optional) optional offset into the array-like.</param>
    abstract toArray: ?array:ArrayLike<float> * ?offset:float -> ArrayLike<float>
    abstract extractPosition: m:Matrix4 -> Matrix4
    abstract setRotationFromQuaternion: q:Quaternion -> Matrix4
    abstract multiplyVector3: v:obj -> obj
    abstract multiplyVector4: v:obj -> obj
    abstract multiplyVector3Array: array:ResizeArray<float> -> ResizeArray<float>
    abstract rotateAxis: v:obj -> unit
    abstract crossVector: v:obj -> unit
    abstract flattenToArrayOffset: array:ResizeArray<float> * offset:float -> ResizeArray<float>

/// A 4x4 Matrix.
[<AllowNullLiteral>]
type Matrix4Static =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Matrix4








[<AllowNullLiteral>]
type Plane =
    abstract normal: Vector3 with get, set
    abstract constant: float with get, set
    abstract isPlane: obj
    abstract set: normal:Vector3 * constant:float -> Plane
    abstract setComponents: x:float * y:float * z:float * w:float -> Plane
    abstract setFromNormalAndCoplanarPoint: normal:Vector3 * point:Vector3 -> Plane
    abstract setFromCoplanarPoints: a:Vector3 * b:Vector3 * c:Vector3 -> Plane
    abstract clone: unit -> Plane
    abstract copy: plane:Plane -> Plane
    abstract normalize: unit -> Plane
    abstract negate: unit -> Plane
    abstract distanceToPoint: point:Vector3 -> float
    abstract distanceToSphere: sphere:Sphere -> float
    abstract projectPoint: point:Vector3 * target:Vector3 -> Vector3
    abstract orthoPoint: point:Vector3 * target:Vector3 -> Vector3
    abstract intersectLine: line:Line3 * target:Vector3 -> Vector3 option
    abstract intersectsLine: line:Line3 -> bool
    abstract intersectsBox: box:Box3 -> bool
    abstract intersectsSphere: sphere:Sphere -> bool
    abstract coplanarPoint: target:Vector3 -> Vector3
    abstract applyMatrix4: matrix:Matrix4 * ?optionalNormalMatrix:Matrix3 -> Plane
    abstract translate: offset:Vector3 -> Plane
    abstract equals: plane:Plane -> bool
    abstract isIntersectionLine: l:obj -> obj

[<AllowNullLiteral>]
type PlaneStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?normal:Vector3 * ?constant:float -> Plane





/// Implementation of a quaternion. This is used for rotating things without incurring in the dreaded gimbal lock issue, amongst other advantages.
[<AllowNullLiteral>]
type Quaternion =
    abstract x: float with get, set
    abstract y: float with get, set
    abstract z: float with get, set
    abstract w: float with get, set
    abstract isQuaternion: obj
    /// Sets values of this quaternion.
    abstract set: x:float * y:float * z:float * w:float -> Quaternion
    /// Clones this quaternion.
    abstract clone: unit -> Quaternion
    /// Copies values of q to this quaternion.
    abstract copy: q:Quaternion -> Quaternion
    /// Sets this quaternion from rotation specified by Euler angles.
    abstract setFromEuler: euler:Euler -> Quaternion
    /// Sets this quaternion from rotation specified by axis and angle.
    /// Adapted from http://www.euclideanspace.com/maths/geometry/rotations/conversions/angleToQuaternion/index.htm.
    /// Axis have to be normalized, angle is in radians.
    abstract setFromAxisAngle: axis:Vector3 * angle:float -> Quaternion
    /// Sets this quaternion from rotation component of m. Adapted from http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm.
    abstract setFromRotationMatrix: m:Matrix4 -> Quaternion
    abstract setFromUnitVectors: vFrom:Vector3 * vTo:Vector3 -> Quaternion
    abstract angleTo: q:Quaternion -> float
    abstract rotateTowards: q:Quaternion * step:float -> Quaternion
    /// Inverts this quaternion.
    abstract inverse: unit -> Quaternion
    abstract conjugate: unit -> Quaternion
    abstract dot: v:Quaternion -> float
    abstract lengthSq: unit -> float
    /// Computes length of this quaternion.
    abstract length: unit -> float
    /// Normalizes this quaternion.
    abstract normalize: unit -> Quaternion
    /// Multiplies this quaternion by b.
    abstract multiply: q:Quaternion -> Quaternion
    abstract premultiply: q:Quaternion -> Quaternion
    /// Sets this quaternion to a x b
    /// Adapted from http://www.euclideanspace.com/maths/algebra/realNormedAlgebra/quaternions/code/index.htm.
    abstract multiplyQuaternions: a:Quaternion * b:Quaternion -> Quaternion
    abstract slerp: qb:Quaternion * t:float -> Quaternion
    abstract equals: v:Quaternion -> bool
    /// <summary>Sets this quaternion's x, y, z and w value from the provided array.</summary>
    /// <param name="array">the source array.</param>
    /// <param name="offset">(optional) offset into the array. Default is 0.</param>
    abstract fromArray: array:ResizeArray<float> * ?offset:float -> Quaternion
    /// <summary>Sets this quaternion's x, y, z and w value from the provided array-like.</summary>
    /// <param name="array">the source array-like.</param>
    /// <param name="offset">(optional) offset into the array-like. Default is 0.</param>
    abstract fromArray: array:ArrayLike<float> * ?offset:float -> Quaternion
    /// <summary>Returns an array [x, y, z, w], or copies x, y, z and w into the provided array.</summary>
    /// <param name="array">(optional) array to store the quaternion to. If this is not provided, a new array will be created.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    /// <summary>Copies x, y, z and w into the provided array-like.</summary>
    /// <param name="array">array-like to store the quaternion to.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: array:ArrayLike<float> * ?offset:float -> ArrayLike<float>
    abstract _onChange: callback:Function -> Quaternion
    abstract _onChangeCallback: Function with get, set
    abstract multiplyVector3: v:obj -> obj

/// Implementation of a quaternion. This is used for rotating things without incurring in the dreaded gimbal lock issue, amongst other advantages.
[<AllowNullLiteral>]
type QuaternionStatic =
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    /// <param name="z">z coordinate</param>
    /// <param name="w">w coordinate</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?x:float * ?y:float * ?z:float * ?w:float -> Quaternion
    /// Adapted from http://www.euclideanspace.com/maths/algebra/realNormedAlgebra/quaternions/slerp/.
    abstract slerp: qa:Quaternion * qb:Quaternion * qm:Quaternion * t:float -> Quaternion

    abstract slerpFlat: dst:ResizeArray<float>
                        * dstOffset:float
                        * src0:ResizeArray<float>
                        * srcOffset:float
                        * src1:ResizeArray<float>
                        * stcOffset1:float
                        * t:float
                        -> Quaternion

    abstract multiplyQuaternionsFlat: dst:ResizeArray<float>
                                      * dstOffset:float
                                      * src0:ResizeArray<float>
                                      * srcOffset:float
                                      * src1:ResizeArray<float>
                                      * stcOffset1:float
                                      -> ResizeArray<float>







[<AllowNullLiteral>]
type Ray =
    abstract origin: Vector3 with get, set
    abstract direction: Vector3 with get, set
    abstract set: origin:Vector3 * direction:Vector3 -> Ray
    abstract clone: unit -> Ray
    abstract copy: ray:Ray -> Ray
    abstract at: t:float * target:Vector3 -> Vector3
    abstract lookAt: v:Vector3 -> Ray
    abstract recast: t:float -> Ray
    abstract closestPointToPoint: point:Vector3 * target:Vector3 -> Vector3
    abstract distanceToPoint: point:Vector3 -> float
    abstract distanceSqToPoint: point:Vector3 -> float

    abstract distanceSqToSegment: v0:Vector3
                                  * v1:Vector3
                                  * ?optionalPointOnRay:Vector3
                                  * ?optionalPointOnSegment:Vector3
                                  -> float

    abstract intersectSphere: sphere:Sphere * target:Vector3 -> Vector3 option
    abstract intersectsSphere: sphere:Sphere -> bool
    abstract distanceToPlane: plane:Plane -> float
    abstract intersectPlane: plane:Plane * target:Vector3 -> Vector3 option
    abstract intersectsPlane: plane:Plane -> bool
    abstract intersectBox: box:Box3 * target:Vector3 -> Vector3 option
    abstract intersectsBox: box:Box3 -> bool

    abstract intersectTriangle: a:Vector3
                                * b:Vector3
                                * c:Vector3
                                * backfaceCulling:bool
                                * target:Vector3
                                -> Vector3 option

    abstract applyMatrix4: matrix4:Matrix4 -> Ray
    abstract equals: ray:Ray -> bool
    abstract isIntersectionBox: b:obj -> obj
    abstract isIntersectionPlane: p:obj -> obj
    abstract isIntersectionSphere: s:obj -> obj

[<AllowNullLiteral>]
type RayStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?origin:Vector3 * ?direction:Vector3 -> Ray






[<AllowNullLiteral>]
type Sphere =
    abstract center: Vector3 with get, set
    abstract radius: float with get, set
    abstract set: center:Vector3 * radius:float -> Sphere
    abstract setFromPoints: points:ResizeArray<Vector3> * ?optionalCenter:Vector3 -> Sphere
    abstract clone: unit -> Sphere
    abstract copy: sphere:Sphere -> Sphere
    abstract isEmpty: unit -> bool
    abstract makeEmpty: unit -> Sphere
    abstract containsPoint: point:Vector3 -> bool
    abstract distanceToPoint: point:Vector3 -> float
    abstract intersectsSphere: sphere:Sphere -> bool
    abstract intersectsBox: box:Box3 -> bool
    abstract intersectsPlane: plane:Plane -> bool
    abstract clampPoint: point:Vector3 * target:Vector3 -> Vector3
    abstract getBoundingBox: target:Box3 -> Box3
    abstract applyMatrix4: matrix:Matrix4 -> Sphere
    abstract translate: offset:Vector3 -> Sphere
    abstract equals: sphere:Sphere -> bool
    abstract empty: unit -> obj

[<AllowNullLiteral>]
type SphereStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?center:Vector3 * ?radius:float -> Sphere



[<AllowNullLiteral>]
type Spherical =
    abstract radius: float with get, set
    abstract phi: float with get, set
    abstract theta: float with get, set
    abstract set: radius:float * phi:float * theta:float -> Spherical
    abstract clone: unit -> Spherical
    abstract copy: other:Spherical -> Spherical
    abstract makeSafe: unit -> Spherical
    abstract setFromVector3: v:Vector3 -> Spherical
    abstract setFromCartesianCoords: x:float * y:float * z:float -> Spherical

[<AllowNullLiteral>]
type SphericalStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?radius:float * ?phi:float * ?theta:float -> Spherical



[<AllowNullLiteral>]
type SphericalHarmonics3 =
    abstract coefficients: ResizeArray<Vector3> with get, set
    abstract isSphericalHarmonics3: obj
    abstract set: coefficients:ResizeArray<Vector3> -> SphericalHarmonics3
    abstract zero: unit -> SphericalHarmonics3
    abstract add: sh:SphericalHarmonics3 -> SphericalHarmonics3
    abstract addScaledSH: sh:SphericalHarmonics3 * s:float -> SphericalHarmonics3
    abstract scale: s:float -> SphericalHarmonics3
    abstract lerp: sh:SphericalHarmonics3 * alpha:float -> SphericalHarmonics3
    abstract equals: sh:SphericalHarmonics3 -> bool
    abstract copy: sh:SphericalHarmonics3 -> SphericalHarmonics3
    abstract clone: unit -> SphericalHarmonics3
    /// <summary>Sets the values of this spherical harmonics from the provided array.</summary>
    /// <param name="array">the source array.</param>
    /// <param name="offset">(optional) offset into the array. Default is 0.</param>
    abstract fromArray: array:ResizeArray<float> * ?offset:float -> SphericalHarmonics3
    /// <summary>Sets the values of this spherical harmonics from the provided array-like.</summary>
    /// <param name="array">the source array-like.</param>
    /// <param name="offset">(optional) offset into the array-like. Default is 0.</param>
    abstract fromArray: array:ArrayLike<float> * ?offset:float -> SphericalHarmonics3
    /// <summary>Returns an array with the values of this spherical harmonics, or copies them into the provided array.</summary>
    /// <param name="array">(optional) array to store the spherical harmonics to. If this is not provided, a new array will be created.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    /// <summary>Returns an array with the values of this spherical harmonics, or copies them into the provided array-like.</summary>
    /// <param name="array">array-like to store the spherical harmonics to.</param>
    /// <param name="offset">(optional) optional offset into the array-like.</param>
    abstract toArray: array:ArrayLike<float> * ?offset:float -> ArrayLike<float>
    abstract getAt: normal:Vector3 * target:Vector3 -> Vector3
    abstract getIrradianceAt: normal:Vector3 * target:Vector3 -> Vector3

[<AllowNullLiteral>]
type SphericalHarmonics3Static =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> SphericalHarmonics3

    abstract getBasisAt: normal:Vector3 * shBasis:ResizeArray<float> -> unit






[<AllowNullLiteral>]
type Triangle =
    abstract a: Vector3 with get, set
    abstract b: Vector3 with get, set
    abstract c: Vector3 with get, set
    abstract set: a:Vector3 * b:Vector3 * c:Vector3 -> Triangle
    abstract setFromPointsAndIndices: points:ResizeArray<Vector3> * i0:float * i1:float * i2:float -> Triangle
    abstract clone: unit -> Triangle
    abstract copy: triangle:Triangle -> Triangle
    abstract getArea: unit -> float
    abstract getMidpoint: target:Vector3 -> Vector3
    abstract getNormal: target:Vector3 -> Vector3
    abstract getPlane: target:Plane -> Plane
    abstract getBarycoord: point:Vector3 * target:Vector3 -> Vector3
    abstract getUV: point:Vector3 * uv1:Vector2 * uv2:Vector2 * uv3:Vector2 * target:Vector2 -> Vector2
    abstract containsPoint: point:Vector3 -> bool
    abstract intersectsBox: box:Box3 -> bool
    abstract isFrontFacing: direction:Vector3 -> bool
    abstract closestPointToPoint: point:Vector3 * target:Vector3 -> Vector3
    abstract equals: triangle:Triangle -> bool

[<AllowNullLiteral>]
type TriangleStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?a:Vector3 * ?b:Vector3 * ?c:Vector3 -> Triangle

    abstract getNormal: a:Vector3 * b:Vector3 * c:Vector3 * target:Vector3 -> Vector3
    abstract getBarycoord: point:Vector3 * a:Vector3 * b:Vector3 * c:Vector3 * target:Vector3 -> Vector3
    abstract containsPoint: point:Vector3 * a:Vector3 * b:Vector3 * c:Vector3 -> bool

    abstract getUV: point:Vector3
                    * p1:Vector3
                    * p2:Vector3
                    * p3:Vector3
                    * uv1:Vector2
                    * uv2:Vector2
                    * uv3:Vector2
                    * target:Vector2
                    -> Vector2

    abstract isFrontFacing: a:Vector3 * b:Vector3 * c:Vector3 * direction:Vector3 -> bool




/// ( interface Vector<T> )
///
/// Abstract interface of {@link https://github.com/mrdoob/three.js/blob/master/src/math/Vector2.js|Vector2},
/// {@link https://github.com/mrdoob/three.js/blob/master/src/math/Vector3.js|Vector3}
/// and {@link https://github.com/mrdoob/three.js/blob/master/src/math/Vector4.js|Vector4}.
///
/// Currently the members of Vector is NOT type safe because it accepts different typed vectors.
///
/// Those definitions will be changed when TypeScript innovates Generics to be type safe.
[<AllowNullLiteral>]
type Vector =
    abstract setComponent: index:float * value:float -> Vector
    abstract getComponent: index:float -> float
    abstract set: [<ParamArray>] args:ResizeArray<float> -> Vector
    abstract setScalar: scalar:float -> Vector
    /// copy(v:T):T;
    abstract copy: v:Vector -> Vector
    /// NOTE: The second argument is deprecated.
    ///
    /// add(v:T):T;
    abstract add: v:Vector -> Vector
    /// addVectors(a:T, b:T):T;
    abstract addVectors: a:Vector * b:Vector -> Vector
    abstract addScaledVector: vector:Vector * scale:float -> Vector
    /// Adds the scalar value s to this vector's values.
    abstract addScalar: scalar:float -> Vector
    /// sub(v:T):T;
    abstract sub: v:Vector -> Vector
    /// subVectors(a:T, b:T):T;
    abstract subVectors: a:Vector * b:Vector -> Vector
    /// multiplyScalar(s:number):T;
    abstract multiplyScalar: s:float -> Vector
    /// divideScalar(s:number):T;
    abstract divideScalar: s:float -> Vector
    /// negate():T;
    abstract negate: unit -> Vector
    /// dot(v:T):T;
    abstract dot: v:Vector -> float
    /// lengthSq():number;
    abstract lengthSq: unit -> float
    /// length():number;
    abstract length: unit -> float
    /// normalize():T;
    abstract normalize: unit -> Vector
    /// NOTE: Vector4 doesn't have the property.
    ///
    /// distanceTo(v:T):number;
    abstract distanceTo: v:Vector -> float
    /// NOTE: Vector4 doesn't have the property.
    ///
    /// distanceToSquared(v:T):number;
    abstract distanceToSquared: v:Vector -> float
    /// setLength(l:number):T;
    abstract setLength: l:float -> Vector
    /// lerp(v:T, alpha:number):T;
    abstract lerp: v:Vector * alpha:float -> Vector
    /// equals(v:T):boolean;
    abstract equals: v:Vector -> bool
    /// clone():T;
    abstract clone: unit -> Vector

/// 2D vector.
///
/// ( class Vector2 implements Vector<Vector2> )
[<AllowNullLiteral>]
type Vector2 =
    inherit Vector
    abstract x: float with get, set
    abstract y: float with get, set
    abstract width: float with get, set
    abstract height: float with get, set
    abstract isVector2: obj
    /// Sets value of this vector.
    abstract set: x:float * y:float -> Vector2
    /// Sets the x and y values of this vector both equal to scalar.
    abstract setScalar: scalar:float -> Vector2
    /// Sets X component of this vector.
    abstract setX: x:float -> Vector2
    /// Sets Y component of this vector.
    abstract setY: y:float -> Vector2
    /// Sets a component of this vector.
    abstract setComponent: index:float * value:float -> Vector2
    /// Gets a component of this vector.
    abstract getComponent: index:float -> float
    /// Returns a new Vector2 instance with the same `x` and `y` values.
    abstract clone: unit -> Vector2
    /// Copies value of v to this vector.
    abstract copy: v:Vector2 -> Vector2
    /// Adds v to this vector.
    abstract add: v:Vector2 * ?w:Vector2 -> Vector2
    /// Adds the scalar value s to this vector's x and y values.
    abstract addScalar: s:float -> Vector2
    /// Sets this vector to a + b.
    abstract addVectors: a:Vector2 * b:Vector2 -> Vector2
    /// Adds the multiple of v and s to this vector.
    abstract addScaledVector: v:Vector2 * s:float -> Vector2
    /// Subtracts v from this vector.
    abstract sub: v:Vector2 -> Vector2
    /// Subtracts s from this vector's x and y components.
    abstract subScalar: s:float -> Vector2
    /// Sets this vector to a - b.
    abstract subVectors: a:Vector2 * b:Vector2 -> Vector2
    /// Multiplies this vector by v.
    abstract multiply: v:Vector2 -> Vector2
    /// Multiplies this vector by scalar s.
    abstract multiplyScalar: scalar:float -> Vector2
    /// Divides this vector by v.
    abstract divide: v:Vector2 -> Vector2
    /// Divides this vector by scalar s.
    /// Set vector to ( 0, 0 ) if s == 0.
    abstract divideScalar: s:float -> Vector2
    /// Multiplies this vector (with an implicit 1 as the 3rd component) by m.
    abstract applyMatrix3: m:Matrix3 -> Vector2
    /// If this vector's x or y value is greater than v's x or y value, replace that value with the corresponding min value.
    abstract min: v:Vector2 -> Vector2
    /// If this vector's x or y value is less than v's x or y value, replace that value with the corresponding max value.
    abstract max: v:Vector2 -> Vector2
    /// <summary>If this vector's x or y value is greater than the max vector's x or y value, it is replaced by the corresponding value.
    /// If this vector's x or y value is less than the min vector's x or y value, it is replaced by the corresponding value.</summary>
    /// <param name="min">the minimum x and y values.</param>
    /// <param name="max">the maximum x and y values in the desired range.</param>
    abstract clamp: min:Vector2 * max:Vector2 -> Vector2
    /// <summary>If this vector's x or y values are greater than the max value, they are replaced by the max value.
    /// If this vector's x or y values are less than the min value, they are replaced by the min value.</summary>
    /// <param name="min">the minimum value the components will be clamped to.</param>
    /// <param name="max">the maximum value the components will be clamped to.</param>
    abstract clampScalar: min:float * max:float -> Vector2
    /// <summary>If this vector's length is greater than the max value, it is replaced by the max value.
    /// If this vector's length is less than the min value, it is replaced by the min value.</summary>
    /// <param name="min">the minimum value the length will be clamped to.</param>
    /// <param name="max">the maximum value the length will be clamped to.</param>
    abstract clampLength: min:float * max:float -> Vector2
    /// The components of the vector are rounded down to the nearest integer value.
    abstract floor: unit -> Vector2
    /// The x and y components of the vector are rounded up to the nearest integer value.
    abstract ceil: unit -> Vector2
    /// The components of the vector are rounded to the nearest integer value.
    abstract round: unit -> Vector2
    /// The components of the vector are rounded towards zero (up if negative, down if positive) to an integer value.
    abstract roundToZero: unit -> Vector2
    /// Inverts this vector.
    abstract negate: unit -> Vector2
    /// Computes dot product of this vector and v.
    abstract dot: v:Vector2 -> float
    /// Computes cross product of this vector and v.
    abstract cross: v:Vector2 -> float
    /// Computes squared length of this vector.
    abstract lengthSq: unit -> float
    /// Computes length of this vector.
    abstract length: unit -> float
    abstract lengthManhattan: unit -> float
    /// Computes the Manhattan length of this vector.
    abstract manhattanLength: unit -> float
    /// Normalizes this vector.
    abstract normalize: unit -> Vector2
    /// computes the angle in radians with respect to the positive x-axis
    abstract angle: unit -> float
    /// Computes distance of this vector to v.
    abstract distanceTo: v:Vector2 -> float
    /// Computes squared distance of this vector to v.
    abstract distanceToSquared: v:Vector2 -> float
    abstract distanceToManhattan: v:Vector2 -> float
    /// Computes the Manhattan length (distance) from this vector to the given vector v
    abstract manhattanDistanceTo: v:Vector2 -> float
    /// Normalizes this vector and multiplies it by l.
    abstract setLength: length:float -> Vector2
    /// <summary>Linearly interpolates between this vector and v, where alpha is the distance along the line - alpha = 0 will be this vector, and alpha = 1 will be v.</summary>
    /// <param name="v">vector to interpolate towards.</param>
    /// <param name="alpha">interpolation factor in the closed interval [0, 1].</param>
    abstract lerp: v:Vector2 * alpha:float -> Vector2
    /// <summary>Sets this vector to be the vector linearly interpolated between v1 and v2 where alpha is the distance along the line connecting the two vectors - alpha = 0 will be v1, and alpha = 1 will be v2.</summary>
    /// <param name="v1">the starting vector.</param>
    /// <param name="v2">vector to interpolate towards.</param>
    /// <param name="alpha">interpolation factor in the closed interval [0, 1].</param>
    abstract lerpVectors: v1:Vector2 * v2:Vector2 * alpha:float -> Vector2
    /// Checks for strict equality of this vector and v.
    abstract equals: v:Vector2 -> bool
    /// <summary>Sets this vector's x and y value from the provided array.</summary>
    /// <param name="array">the source array.</param>
    /// <param name="offset">(optional) offset into the array. Default is 0.</param>
    abstract fromArray: array:ResizeArray<float> * ?offset:float -> Vector2
    /// <summary>Sets this vector's x and y value from the provided array-like.</summary>
    /// <param name="array">the source array-like.</param>
    /// <param name="offset">(optional) offset into the array-like. Default is 0.</param>
    abstract fromArray: array:ArrayLike<float> * ?offset:float -> Vector2
    /// <summary>Returns an array [x, y], or copies x and y into the provided array.</summary>
    /// <param name="array">(optional) array to store the vector to. If this is not provided, a new array will be created.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    /// <summary>Copies x and y into the provided array-like.</summary>
    /// <param name="array">array-like to store the vector to.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: array:ArrayLike<float> * ?offset:float -> ArrayLike<float>
    /// <summary>Sets this vector's x and y values from the attribute.</summary>
    /// <param name="attribute">the source attribute.</param>
    /// <param name="index">index in the attribute.</param>
    abstract fromBufferAttribute: attribute:BufferAttribute * index:float -> Vector2
    /// <summary>Rotates the vector around center by angle radians.</summary>
    /// <param name="center">the point around which to rotate.</param>
    /// <param name="angle">the angle to rotate, in radians.</param>
    abstract rotateAround: center:Vector2 * angle:float -> Vector2
    /// Sets this vector's x and y from Math.random
    abstract random: unit -> Vector2

/// 2D vector.
///
/// ( class Vector2 implements Vector<Vector2> )
[<AllowNullLiteral>]
type Vector2Static =
    [<Emit "new $0($1...)">]
    abstract Create: ?x:float * ?y:float -> Vector2











/// 3D vector.
[<AllowNullLiteral>]
type Vector3 =
    inherit Vector
    abstract x: float with get, set
    abstract y: float with get, set
    abstract z: float with get, set
    abstract isVector3: obj
    /// Sets value of this vector.
    abstract set: x:float * y:float * z:float -> Vector3
    /// Sets all values of this vector.
    abstract setScalar: scalar:float -> Vector3
    /// Sets x value of this vector.
    abstract setX: x:float -> Vector3
    /// Sets y value of this vector.
    abstract setY: y:float -> Vector3
    /// Sets z value of this vector.
    abstract setZ: z:float -> Vector3
    abstract setComponent: index:float * value:float -> Vector3
    abstract getComponent: index:float -> float
    /// Clones this vector.
    abstract clone: unit -> Vector3
    /// Copies value of v to this vector.
    abstract copy: v:Vector3 -> Vector3
    /// Adds v to this vector.
    abstract add: v:Vector3 -> Vector3
    /// Adds the scalar value s to this vector's values.
    abstract addScalar: s:float -> Vector3
    abstract addScaledVector: v:Vector3 * s:float -> Vector3
    /// Sets this vector to a + b.
    abstract addVectors: a:Vector3 * b:Vector3 -> Vector3
    /// Subtracts v from this vector.
    abstract sub: a:Vector3 -> Vector3
    abstract subScalar: s:float -> Vector3
    /// Sets this vector to a - b.
    abstract subVectors: a:Vector3 * b:Vector3 -> Vector3
    abstract multiply: v:Vector3 -> Vector3
    /// Multiplies this vector by scalar s.
    abstract multiplyScalar: s:float -> Vector3
    abstract multiplyVectors: a:Vector3 * b:Vector3 -> Vector3
    abstract applyEuler: euler:Euler -> Vector3
    abstract applyAxisAngle: axis:Vector3 * angle:float -> Vector3
    abstract applyMatrix3: m:Matrix3 -> Vector3
    abstract applyNormalMatrix: m:Matrix3 -> Vector3
    abstract applyMatrix4: m:Matrix4 -> Vector3
    abstract applyQuaternion: q:Quaternion -> Vector3
    abstract project: camera:Camera -> Vector3
    abstract unproject: camera:Camera -> Vector3
    abstract transformDirection: m:Matrix4 -> Vector3
    abstract divide: v:Vector3 -> Vector3
    /// Divides this vector by scalar s.
    /// Set vector to ( 0, 0, 0 ) if s == 0.
    abstract divideScalar: s:float -> Vector3
    abstract min: v:Vector3 -> Vector3
    abstract max: v:Vector3 -> Vector3
    abstract clamp: min:Vector3 * max:Vector3 -> Vector3
    abstract clampScalar: min:float * max:float -> Vector3
    abstract clampLength: min:float * max:float -> Vector3
    abstract floor: unit -> Vector3
    abstract ceil: unit -> Vector3
    abstract round: unit -> Vector3
    abstract roundToZero: unit -> Vector3
    /// Inverts this vector.
    abstract negate: unit -> Vector3
    /// Computes dot product of this vector and v.
    abstract dot: v:Vector3 -> float
    /// Computes squared length of this vector.
    abstract lengthSq: unit -> float
    /// Computes length of this vector.
    abstract length: unit -> float
    /// Computes Manhattan length of this vector.
    /// http://en.wikipedia.org/wiki/Taxicab_geometry
    abstract lengthManhattan: unit -> float
    /// Computes the Manhattan length of this vector.
    abstract manhattanLength: unit -> float
    /// Computes the Manhattan length (distance) from this vector to the given vector v
    abstract manhattanDistanceTo: v:Vector3 -> float
    /// Normalizes this vector.
    abstract normalize: unit -> Vector3
    /// Normalizes this vector and multiplies it by l.
    abstract setLength: l:float -> Vector3
    /// lerp(v:T, alpha:number):T;
    abstract lerp: v:Vector3 * alpha:float -> Vector3
    abstract lerpVectors: v1:Vector3 * v2:Vector3 * alpha:float -> Vector3
    /// Sets this vector to cross product of itself and v.
    abstract cross: a:Vector3 -> Vector3
    /// Sets this vector to cross product of a and b.
    abstract crossVectors: a:Vector3 * b:Vector3 -> Vector3
    abstract projectOnVector: v:Vector3 -> Vector3
    abstract projectOnPlane: planeNormal:Vector3 -> Vector3
    abstract reflect: vector:Vector3 -> Vector3
    abstract angleTo: v:Vector3 -> float
    /// Computes distance of this vector to v.
    abstract distanceTo: v:Vector3 -> float
    /// Computes squared distance of this vector to v.
    abstract distanceToSquared: v:Vector3 -> float
    abstract distanceToManhattan: v:Vector3 -> float
    abstract setFromSpherical: s:Spherical -> Vector3
    abstract setFromSphericalCoords: r:float * phi:float * theta:float -> Vector3
    abstract setFromCylindrical: s:Cylindrical -> Vector3
    abstract setFromCylindricalCoords: radius:float * theta:float * y:float -> Vector3
    abstract setFromMatrixPosition: m:Matrix4 -> Vector3
    abstract setFromMatrixScale: m:Matrix4 -> Vector3
    abstract setFromMatrixColumn: matrix:Matrix4 * index:float -> Vector3
    abstract setFromMatrix3Column: matrix:Matrix3 * index:float -> Vector3
    /// Checks for strict equality of this vector and v.
    abstract equals: v:Vector3 -> bool
    /// <summary>Sets this vector's x, y and z value from the provided array.</summary>
    /// <param name="array">the source array.</param>
    /// <param name="offset">(optional) offset into the array. Default is 0.</param>
    abstract fromArray: array:ResizeArray<float> * ?offset:float -> Vector3
    /// <summary>Sets this vector's x, y and z value from the provided array-like.</summary>
    /// <param name="array">the source array-like.</param>
    /// <param name="offset">(optional) offset into the array-like. Default is 0.</param>
    abstract fromArray: array:ArrayLike<float> * ?offset:float -> Vector3
    /// <summary>Returns an array [x, y, z], or copies x, y and z into the provided array.</summary>
    /// <param name="array">(optional) array to store the vector to. If this is not provided, a new array will be created.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    /// <summary>Copies x, y and z into the provided array-like.</summary>
    /// <param name="array">array-like to store the vector to.</param>
    /// <param name="offset">(optional) optional offset into the array-like.</param>
    abstract toArray: array:ArrayLike<float> * ?offset:float -> ArrayLike<float>
    abstract fromBufferAttribute: attribute:BufferAttribute * index:float -> Vector3
    /// Sets this vector's x, y and z from Math.random
    abstract random: unit -> Vector3

/// 3D vector.
[<AllowNullLiteral>]
type Vector3Static =
    [<Emit "new $0($1...)">]
    abstract Create: ?x:float * ?y:float * ?z:float -> Vector3







/// 4D vector.
///
/// ( class Vector4 implements Vector<Vector4> )
[<AllowNullLiteral>]
type Vector4 =
    inherit Vector
    abstract x: float with get, set
    abstract y: float with get, set
    abstract z: float with get, set
    abstract w: float with get, set
    abstract width: float with get, set
    abstract height: float with get, set
    abstract isVector4: obj
    /// Sets value of this vector.
    abstract set: x:float * y:float * z:float * w:float -> Vector4
    /// Sets all values of this vector.
    abstract setScalar: scalar:float -> Vector4
    /// Sets X component of this vector.
    abstract setX: x:float -> Vector4
    /// Sets Y component of this vector.
    abstract setY: y:float -> Vector4
    /// Sets Z component of this vector.
    abstract setZ: z:float -> Vector4
    /// Sets w component of this vector.
    abstract setW: w:float -> Vector4
    abstract setComponent: index:float * value:float -> Vector4
    abstract getComponent: index:float -> float
    /// Clones this vector.
    abstract clone: unit -> Vector4
    /// Copies value of v to this vector.
    abstract copy: v:Vector4 -> Vector4
    /// Adds v to this vector.
    abstract add: v:Vector4 -> Vector4
    /// Adds the scalar value s to this vector's values.
    abstract addScalar: scalar:float -> Vector4
    /// Sets this vector to a + b.
    abstract addVectors: a:Vector4 * b:Vector4 -> Vector4
    abstract addScaledVector: v:Vector4 * s:float -> Vector4
    /// Subtracts v from this vector.
    abstract sub: v:Vector4 -> Vector4
    abstract subScalar: s:float -> Vector4
    /// Sets this vector to a - b.
    abstract subVectors: a:Vector4 * b:Vector4 -> Vector4
    /// Multiplies this vector by scalar s.
    abstract multiplyScalar: s:float -> Vector4
    abstract applyMatrix4: m:Matrix4 -> Vector4
    /// Divides this vector by scalar s.
    /// Set vector to ( 0, 0, 0 ) if s == 0.
    abstract divideScalar: s:float -> Vector4
    /// <summary>http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToAngle/index.htm</summary>
    /// <param name="q">is assumed to be normalized</param>
    abstract setAxisAngleFromQuaternion: q:Quaternion -> Vector4
    /// <summary>http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToAngle/index.htm</summary>
    /// <param name="m">assumes the upper 3x3 of m is a pure rotation matrix (i.e, unscaled)</param>
    abstract setAxisAngleFromRotationMatrix: m:Matrix3 -> Vector4
    abstract min: v:Vector4 -> Vector4
    abstract max: v:Vector4 -> Vector4
    abstract clamp: min:Vector4 * max:Vector4 -> Vector4
    abstract clampScalar: min:float * max:float -> Vector4
    abstract floor: unit -> Vector4
    abstract ceil: unit -> Vector4
    abstract round: unit -> Vector4
    abstract roundToZero: unit -> Vector4
    /// Inverts this vector.
    abstract negate: unit -> Vector4
    /// Computes dot product of this vector and v.
    abstract dot: v:Vector4 -> float
    /// Computes squared length of this vector.
    abstract lengthSq: unit -> float
    /// Computes length of this vector.
    abstract length: unit -> float
    /// Computes the Manhattan length of this vector.
    abstract manhattanLength: unit -> float
    /// Normalizes this vector.
    abstract normalize: unit -> Vector4
    /// Normalizes this vector and multiplies it by l.
    abstract setLength: length:float -> Vector4
    /// Linearly interpolate between this vector and v with alpha factor.
    abstract lerp: v:Vector4 * alpha:float -> Vector4
    abstract lerpVectors: v1:Vector4 * v2:Vector4 * alpha:float -> Vector4
    /// Checks for strict equality of this vector and v.
    abstract equals: v:Vector4 -> bool
    /// <summary>Sets this vector's x, y, z and w value from the provided array.</summary>
    /// <param name="array">the source array.</param>
    /// <param name="offset">(optional) offset into the array. Default is 0.</param>
    abstract fromArray: array:ResizeArray<float> * ?offset:float -> Vector4
    /// <summary>Sets this vector's x, y, z and w value from the provided array-like.</summary>
    /// <param name="array">the source array-like.</param>
    /// <param name="offset">(optional) offset into the array-like. Default is 0.</param>
    abstract fromArray: array:ArrayLike<float> * ?offset:float -> Vector4
    /// <summary>Returns an array [x, y, z, w], or copies x, y, z and w into the provided array.</summary>
    /// <param name="array">(optional) array to store the vector to. If this is not provided, a new array will be created.</param>
    /// <param name="offset">(optional) optional offset into the array.</param>
    abstract toArray: ?array:ResizeArray<float> * ?offset:float -> ResizeArray<float>
    /// <summary>Copies x, y, z and w into the provided array-like.</summary>
    /// <param name="array">array-like to store the vector to.</param>
    /// <param name="offset">(optional) optional offset into the array-like.</param>
    abstract toArray: array:ArrayLike<float> * ?offset:float -> ArrayLike<float>
    abstract fromBufferAttribute: attribute:BufferAttribute * index:float -> Vector4
    /// Sets this vector's x, y, z and w from Math.random
    abstract random: unit -> Vector4

/// 4D vector.
///
/// ( class Vector4 implements Vector<Vector4> )
[<AllowNullLiteral>]
type Vector4Static =
    [<Emit "new $0($1...)">]
    abstract Create: ?x:float * ?y:float * ?z:float * ?w:float -> Vector4



[<AllowNullLiteral>]
type Bone =
    inherit Object3D
    abstract isBone: obj
    abstract ``type``: string with get, set

[<AllowNullLiteral>]
type BoneStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Bone



[<AllowNullLiteral>]
type Group =
    inherit Object3D
    abstract ``type``: string with get, set
    abstract isGroup: obj

[<AllowNullLiteral>]
type GroupStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Group








type InstancedMesh<'TMaterial> = InstancedMesh<obj, 'TMaterial>

type InstancedMesh = InstancedMesh<obj, obj>

[<AllowNullLiteral>]
type InstancedMesh<'TGeometry, 'TMaterial> =
    inherit Mesh
    abstract count: float with get, set
    abstract instanceMatrix: BufferAttribute with get, set
    abstract isInstancedMesh: obj
    abstract getMatrixAt: index:float * matrix:Matrix4 -> unit
    abstract setMatrixAt: index:float * matrix:Matrix4 -> unit

[<AllowNullLiteral>]
type InstancedMeshStatic =
    [<Emit "new $0($1...)">]
    abstract Create: geometry:'TGeometry * material:'TMaterial * count:float -> InstancedMesh<'TGeometry, 'TMaterial>








type Line<'TMaterial> = Line<obj, 'TMaterial>

type Line = Line<obj, obj>

[<AllowNullLiteral>]
type Line<'TGeometry, 'TMaterial> =
    inherit Object3D
    abstract geometry: 'TGeometry with get, set
    abstract material: 'TMaterial with get, set
    abstract ``type``: LineType with get, set
    abstract isLine: obj
    abstract morphTargetInfluences: ResizeArray<float> with get, set
    abstract morphTargetDictionary: LineMorphTargetDictionary with get, set
    abstract computeLineDistances: unit -> Line<'TGeometry, 'TMaterial>
    abstract raycast: raycaster:Raycaster * intersects:ResizeArray<Intersection> -> unit
    abstract updateMorphTargets: unit -> unit

[<AllowNullLiteral>]
type LineStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?geometry:'TGeometry * ?material:'TMaterial * ?mode:float -> Line<'TGeometry, 'TMaterial>

[<StringEnum>]
[<RequireQualifiedAccess>]
type LineType =
    | [<CompiledName "Line">] Line
    | [<CompiledName "LineLoop">] LineLoop
    | [<CompiledName "LineSegments">] LineSegments

[<AllowNullLiteral>]
type LineMorphTargetDictionary =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: key:string -> float with get, set






type LineLoop<'TMaterial> = LineLoop<obj, 'TMaterial>

type LineLoop = LineLoop<obj, obj>

[<AllowNullLiteral>]
type LineLoop<'TGeometry, 'TMaterial> =
    inherit Line
    abstract ``type``: string with get, set
    abstract isLineLoop: obj

[<AllowNullLiteral>]
type LineLoopStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?geometry:'TGeometry * ?material:'TMaterial -> LineLoop<'TGeometry, 'TMaterial>




[<Import("LineStrip", "three")>]
let LineStrip: float = jsNative

[<Import("LinePieces", "three")>]
let LinePieces: float = jsNative


type LineSegments<'TMaterial> = LineSegments<obj, 'TMaterial>

type LineSegments = LineSegments<obj, obj>

[<AllowNullLiteral>]
type LineSegments<'TGeometry, 'TMaterial> =
    inherit Line
    abstract ``type``: string with get, set
    abstract isLineSegments: obj

[<AllowNullLiteral>]
type LineSegmentsStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?geometry:'TGeometry * ?material:'TMaterial * ?mode:float -> LineSegments<'TGeometry, 'TMaterial>






[<AllowNullLiteral>]
type LOD =
    inherit Object3D
    abstract ``type``: string with get, set
    abstract levels: ResizeArray<LODLevels> with get, set
    abstract autoUpdate: bool with get, set
    abstract isLOD: obj
    abstract addLevel: object:Object3D * ?distance:float -> LOD
    abstract getCurrentLevel: unit -> float
    abstract getObjectForDistance: distance:float -> Object3D option
    abstract raycast: raycaster:Raycaster * intersects:ResizeArray<Intersection> -> unit
    abstract update: camera:Camera -> unit
    abstract toJSON: meta:obj -> obj
    abstract objects: ResizeArray<obj> with get, set

[<AllowNullLiteral>]
type LODStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> LOD

[<AllowNullLiteral>]
type LODLevels =
    abstract distance: float with get, set
    abstract object: Object3D with get, set








type Mesh<'TMaterial> = Mesh<obj, 'TMaterial>

type Mesh = Mesh<obj, obj>

[<AllowNullLiteral>]
type Mesh<'TGeometry, 'TMaterial> =
    inherit Object3D
    abstract geometry: 'TGeometry with get, set
    abstract material: 'TMaterial with get, set
    abstract morphTargetInfluences: ResizeArray<float> with get, set
    abstract morphTargetDictionary: MeshMorphTargetDictionary with get, set
    abstract isMesh: obj
    abstract ``type``: string with get, set
    abstract updateMorphTargets: unit -> unit
    abstract raycast: raycaster:Raycaster * intersects:ResizeArray<Intersection> -> unit

[<AllowNullLiteral>]
type MeshStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?geometry:'TGeometry * ?material:'TMaterial -> Mesh<'TGeometry, 'TMaterial>

[<AllowNullLiteral>]
type MeshMorphTargetDictionary =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: key:string -> float with get, set








type Points<'TMaterial> = Points<obj, 'TMaterial>

type Points = Points<obj, obj>

/// A class for displaying particles in the form of variable size points. For example, if using the WebGLRenderer, the particles are displayed using GL_POINTS.
[<AllowNullLiteral>]
type Points<'TGeometry, 'TMaterial> =
    inherit Object3D
    abstract ``type``: string with get, set
    abstract morphTargetInfluences: ResizeArray<float> with get, set
    abstract morphTargetDictionary: PointsMorphTargetDictionary with get, set
    abstract isPoints: obj
    /// An instance of Geometry or BufferGeometry, where each vertex designates the position of a particle in the system.
    abstract geometry: 'TGeometry with get, set
    /// An instance of Material, defining the object's appearance. Default is a PointsMaterial with randomised colour.
    abstract material: 'TMaterial with get, set
    abstract raycast: raycaster:Raycaster * intersects:ResizeArray<Intersection> -> unit
    abstract updateMorphTargets: unit -> unit

/// A class for displaying particles in the form of variable size points. For example, if using the WebGLRenderer, the particles are displayed using GL_POINTS.
[<AllowNullLiteral>]
type PointsStatic =
    /// <param name="geometry">An instance of Geometry or BufferGeometry.</param>
    /// <param name="material">An instance of Material (optional).</param>
    [<Emit "new $0($1...)">]
    abstract Create: ?geometry:'TGeometry * ?material:'TMaterial -> Points<'TGeometry, 'TMaterial>

[<AllowNullLiteral>]
type PointsMorphTargetDictionary =
    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: key:string -> float with get, set





[<AllowNullLiteral>]
type Skeleton =
    abstract useVertexTexture: bool with get, set
    abstract bones: ResizeArray<Bone> with get, set
    abstract boneMatrices: Float32Array with get, set
    abstract boneTexture: DataTexture with get, set
    abstract boneInverses: ResizeArray<Matrix4> with get, set
    abstract calculateInverses: bone:Bone -> unit
    abstract pose: unit -> unit
    abstract update: unit -> unit
    abstract clone: unit -> Skeleton
    abstract getBoneByName: name:string -> Bone option
    abstract dispose: unit -> unit

[<AllowNullLiteral>]
type SkeletonStatic =
    [<Emit "new $0($1...)">]
    abstract Create: bones:ResizeArray<Bone> * ?boneInverses:ResizeArray<Matrix4> -> Skeleton








type SkinnedMesh<'TMaterial> = SkinnedMesh<obj, 'TMaterial>

type SkinnedMesh = SkinnedMesh<obj, obj>

[<AllowNullLiteral>]
type SkinnedMesh<'TGeometry, 'TMaterial> =
    inherit Mesh
    abstract bindMode: string with get, set
    abstract bindMatrix: Matrix4 with get, set
    abstract bindMatrixInverse: Matrix4 with get, set
    abstract skeleton: Skeleton with get, set
    abstract isSkinnedMesh: obj
    abstract bind: skeleton:Skeleton * ?bindMatrix:Matrix4 -> unit
    abstract pose: unit -> unit
    abstract normalizeSkinWeights: unit -> unit
    /// Updates global transform of the object and its children.
    abstract updateMatrixWorld: ?force:bool -> unit

[<AllowNullLiteral>]
type SkinnedMeshStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?geometry:'TGeometry
                     * ?material:'TMaterial
                     * ?useVertexTexture:bool
                     -> SkinnedMesh<'TGeometry, 'TMaterial>








[<AllowNullLiteral>]
type Sprite =
    inherit Object3D
    abstract ``type``: string with get, set
    abstract isSprite: obj
    abstract geometry: BufferGeometry with get, set
    abstract material: SpriteMaterial with get, set
    abstract center: Vector2 with get, set
    abstract raycast: raycaster:Raycaster * intersects:ResizeArray<Intersection> -> unit
    abstract copy: source:Sprite -> Sprite

[<AllowNullLiteral>]
type SpriteStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?material:SpriteMaterial -> Sprite




[<AllowNullLiteral>]
type WebGL1Renderer =
    inherit WebGLRenderer
    abstract isWebGL1Renderer: obj

[<AllowNullLiteral>]
type WebGL1RendererStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:WebGLRendererParameters -> WebGL1Renderer






[<AllowNullLiteral>]
type WebGLCubeRenderTarget =
    inherit WebGLRenderTarget
    abstract fromEquirectangularTexture: renderer:WebGLRenderer * texture:Texture -> WebGLCubeRenderTarget

[<AllowNullLiteral>]
type WebGLCubeRenderTargetStatic =
    [<Emit "new $0($1...)">]
    abstract Create: size:float * ?options:WebGLRenderTargetOptions -> WebGLCubeRenderTarget




[<AllowNullLiteral>]
type WebGLMultisampleRenderTarget =
    inherit WebGLRenderTarget
    abstract isWebGLMultisampleRenderTarget: obj
    /// Specifies the number of samples to be used for the renderbuffer storage.However, the maximum supported size for multisampling is platform dependent and defined via gl.MAX_SAMPLES.
    abstract samples: float with get, set

[<AllowNullLiteral>]
type WebGLMultisampleRenderTargetStatic =
    [<Emit "new $0($1...)">]
    abstract Create: width:float * height:float * ?options:WebGLRenderTargetOptions -> WebGLMultisampleRenderTarget



type OffscreenCanvas = obj

[<AllowNullLiteral>]
type Renderer =
    abstract domElement: HTMLCanvasElement with get, set
    abstract render: scene:Object3D * camera:Camera -> unit
    abstract setSize: width:float * height:float * ?updateStyle:bool -> unit

[<AllowNullLiteral>]
type WebGLRendererParameters =
    /// A Canvas where the renderer draws its output.
    abstract canvas: U2<HTMLCanvasElement, OffscreenCanvas> with get, set
    /// A WebGL Rendering Context.
    /// (https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext)
    /// Default is null
    abstract context: WebGLRenderingContext with get, set
    /// shader precision. Can be "highp", "mediump" or "lowp".
    abstract precision: string with get, set
    /// default is false.
    abstract alpha: bool with get, set
    /// default is true.
    abstract premultipliedAlpha: bool with get, set
    /// default is false.
    abstract antialias: bool with get, set
    /// default is true.
    abstract stencil: bool with get, set
    /// default is false.
    abstract preserveDrawingBuffer: bool with get, set
    /// Can be "high-performance", "low-power" or "default"
    abstract powerPreference: string with get, set
    /// default is true.
    abstract depth: bool with get, set
    /// default is false.
    abstract logarithmicDepthBuffer: bool with get, set

[<AllowNullLiteral>]
type WebGLDebug =
    /// Enables error checking and reporting when shader programs are being compiled.
    abstract checkShaderErrors: bool with get, set

type RenderTarget = obj
type WebGLRenderingContext = obj
type WebGLExtensions = obj
type WebGLInfo = obj
type WebGLRenderLists = obj
type WebGLProperties = obj
type WebXRManager = obj
type WebGLCapabilities = obj
type WebGLState = obj
type WebGLProgram = obj
type WebGLShadowMap = obj
type WebGLFramebuffer = obj

/// The WebGL renderer displays your beautifully crafted scenes using WebGL, if your device supports it.
/// This renderer has way better performance than CanvasRenderer.
[<AllowNullLiteral>]
type WebGLRenderer =
    inherit Renderer
    /// A Canvas where the renderer draws its output.
    /// This is automatically created by the renderer in the constructor (if not provided already); you just need to add it to your page.
    abstract domElement: HTMLCanvasElement with get, set
    /// The HTML5 Canvas's 'webgl' context obtained from the canvas where the renderer will draw.
    abstract context: WebGLRenderingContext with get, set
    /// Defines whether the renderer should automatically clear its output before rendering.
    abstract autoClear: bool with get, set
    /// If autoClear is true, defines whether the renderer should clear the color buffer. Default is true.
    abstract autoClearColor: bool with get, set
    /// If autoClear is true, defines whether the renderer should clear the depth buffer. Default is true.
    abstract autoClearDepth: bool with get, set
    /// If autoClear is true, defines whether the renderer should clear the stencil buffer. Default is true.
    abstract autoClearStencil: bool with get, set
    /// Debug configurations.
    abstract debug: WebGLDebug with get, set
    /// Defines whether the renderer should sort objects. Default is true.
    abstract sortObjects: bool with get, set
    abstract clippingPlanes: ResizeArray<obj> with get, set
    abstract localClippingEnabled: bool with get, set
    abstract extensions: WebGLExtensions with get, set
    /// Default is LinearEncoding.
    abstract outputEncoding: TextureEncoding with get, set
    abstract physicallyCorrectLights: bool with get, set
    abstract toneMapping: ToneMapping with get, set
    abstract toneMappingExposure: float with get, set
    /// Default is false.
    abstract shadowMapDebug: bool with get, set
    /// Default is 8.
    abstract maxMorphTargets: float with get, set
    /// Default is 4.
    abstract maxMorphNormals: float with get, set
    abstract info: WebGLInfo with get, set
    abstract shadowMap: WebGLShadowMap with get, set
    abstract pixelRatio: float with get, set
    abstract capabilities: WebGLCapabilities with get, set
    abstract properties: WebGLProperties with get, set
    abstract renderLists: WebGLRenderLists with get, set
    abstract state: WebGLState with get, set
    abstract xr: WebXRManager with get, set
    /// Return the WebGL context.
    abstract getContext: unit -> WebGLRenderingContext
    abstract getContextAttributes: unit -> obj
    abstract forceContextLoss: unit -> unit
    abstract getMaxAnisotropy: unit -> float
    abstract getPrecision: unit -> string
    abstract getPixelRatio: unit -> float
    abstract setPixelRatio: value:float -> unit
    abstract getDrawingBufferSize: target:Vector2 -> Vector2
    abstract setDrawingBufferSize: width:float * height:float * pixelRatio:float -> unit
    abstract getSize: target:Vector2 -> Vector2
    /// Resizes the output canvas to (width, height), and also sets the viewport to fit that size, starting in (0, 0).
    abstract setSize: width:float * height:float * ?updateStyle:bool -> unit
    abstract getCurrentViewport: target:Vector4 -> Vector4
    /// Copies the viewport into target.
    abstract getViewport: target:Vector4 -> Vector4
    /// Sets the viewport to render from (x, y) to (x + width, y + height).
    /// (x, y) is the lower-left corner of the region.
    abstract setViewport: x:U2<Vector4, float> * ?y:float * ?width:float * ?height:float -> unit
    /// Copies the scissor area into target.
    abstract getScissor: target:Vector4 -> Vector4
    /// Sets the scissor area from (x, y) to (x + width, y + height).
    abstract setScissor: x:U2<Vector4, float> * ?y:float * ?width:float * ?height:float -> unit
    /// Returns true if scissor test is enabled; returns false otherwise.
    abstract getScissorTest: unit -> bool
    /// Enable the scissor test. When this is enabled, only the pixels within the defined scissor area will be affected by further renderer actions.
    abstract setScissorTest: enable:bool -> unit
    /// Sets the custom opaque sort function for the WebGLRenderLists. Pass null to use the default painterSortStable function.
    abstract setOpaqueSort: method:Function -> unit
    /// Sets the custom transparent sort function for the WebGLRenderLists. Pass null to use the default reversePainterSortStable function.
    abstract setTransparentSort: method:Function -> unit
    /// Returns a THREE.Color instance with the current clear color.
    abstract getClearColor: unit -> Color
    /// Sets the clear color, using color for the color and alpha for the opacity.
    abstract setClearColor: color:U3<Color, string, float> * ?alpha:float -> unit
    /// Returns a float with the current clear alpha. Ranges from 0 to 1.
    abstract getClearAlpha: unit -> float
    abstract setClearAlpha: alpha:float -> unit
    /// Tells the renderer to clear its color, depth or stencil drawing buffer(s).
    /// Arguments default to true
    abstract clear: ?color:bool * ?depth:bool * ?stencil:bool -> unit
    abstract clearColor: unit -> unit
    abstract clearDepth: unit -> unit
    abstract clearStencil: unit -> unit
    abstract clearTarget: renderTarget:WebGLRenderTarget * color:bool * depth:bool * stencil:bool -> unit
    abstract resetGLState: unit -> unit
    abstract dispose: unit -> unit
    abstract renderBufferImmediate: object:Object3D * program:WebGLProgram -> unit

    abstract renderBufferDirect: camera:Camera
                                 * scene:Scene
                                 * geometry:U2<Geometry, BufferGeometry>
                                 * material:Material
                                 * object:Object3D
                                 * geometryGroup:obj
                                 -> unit
    /// <summary>A build in function that can be used instead of requestAnimationFrame. For WebXR projects this function must be used.</summary>
    /// <param name="callback">The function will be called every available frame. If `null` is passed it will stop any already ongoing animation.</param>
    abstract setAnimationLoop: callback:Function option -> unit
    abstract animate: callback:Function -> unit
    /// Compiles all materials in the scene with the camera. This is useful to precompile shaders before the first rendering.
    abstract compile: scene:Object3D * camera:Camera -> unit
    /// Render a scene or an object using a camera.
    /// The render is done to a previously specified {@link WebGLRenderTarget#renderTarget .renderTarget} set by calling
    /// {@link WebGLRenderer#setRenderTarget .setRenderTarget} or to the canvas as usual.
    ///
    /// By default render buffers are cleared before rendering but you can prevent this by setting the property
    /// {@link WebGLRenderer#autoClear autoClear} to false. If you want to prevent only certain buffers being cleared
    /// you can set either the {@link WebGLRenderer#autoClearColor autoClearColor},
    /// {@link WebGLRenderer#autoClearStencil autoClearStencil} or {@link WebGLRenderer#autoClearDepth autoClearDepth}
    /// properties to false. To forcibly clear one ore more buffers call {@link WebGLRenderer#clear .clear}.
    abstract render: scene:Object3D * camera:Camera -> unit
    /// Returns the current active cube face.
    abstract getActiveCubeFace: unit -> float
    /// Returns the current active mipmap level.
    abstract getActiveMipmapLevel: unit -> float
    /// <summary>Sets the given WebGLFramebuffer. This method can only be used if no render target is set via
    /// {@link WebGLRenderer#setRenderTarget .setRenderTarget}.</summary>
    /// <param name="value">The WebGLFramebuffer.</param>
    abstract setFramebuffer: value:WebGLFramebuffer -> unit
    /// Returns the current render target. If no render target is set, null is returned.
    abstract getRenderTarget: unit -> RenderTarget option
    abstract getCurrentRenderTarget: unit -> RenderTarget option
    /// <summary>Sets the active render target.</summary>
    /// <param name="renderTarget">The {@link WebGLRenderTarget renderTarget} that needs to be activated. When `null` is given, the canvas is set as the active render target instead.</param>
    /// <param name="activeCubeFace">Specifies the active cube side (PX 0, NX 1, PY 2, NY 3, PZ 4, NZ 5) of {@link WebGLCubeRenderTarget}.</param>
    /// <param name="activeMipmapLevel">Specifies the active mipmap level.</param>
    abstract setRenderTarget: renderTarget:RenderTarget option
                              * ?activeCubeFace:float
                              * ?activeMipmapLevel:float
                              -> unit

    abstract readRenderTargetPixels: renderTarget:RenderTarget
                                     * x:float
                                     * y:float
                                     * width:float
                                     * height:float
                                     * buffer:obj
                                     * ?activeCubeFaceIndex:float
                                     -> unit
    /// <summary>Copies a region of the currently bound framebuffer into the selected mipmap level of the selected texture.
    /// This region is defined by the size of the destination texture's mip level, offset by the input position.</summary>
    /// <param name="position">Specifies the pixel offset from which to copy out of the framebuffer.</param>
    /// <param name="texture">Specifies the destination texture.</param>
    /// <param name="level">Specifies the destination mipmap level of the texture.</param>
    abstract copyFramebufferToTexture: position:Vector2 * texture:Texture * ?level:float -> unit
    /// <summary>Copies srcTexture to the specified level of dstTexture, offset by the input position.</summary>
    /// <param name="position">Specifies the pixel offset into the dstTexture where the copy will occur.</param>
    /// <param name="srcTexture">Specifies the source texture.</param>
    /// <param name="dstTexture">Specifies the destination texture.</param>
    /// <param name="level">Specifies the destination mipmap level of the texture.</param>
    abstract copyTextureToTexture: position:Vector2 * srcTexture:Texture * dstTexture:Texture * ?level:float -> unit
    /// <summary>Initializes the given texture. Can be used to preload a texture rather than waiting until first render (which can cause noticeable lags due to decode and GPU upload overhead).</summary>
    /// <param name="texture">The texture to Initialize.</param>
    abstract initTexture: texture:Texture -> unit
    abstract gammaFactor: float with get, set
    abstract vr: bool with get, set
    abstract shadowMapEnabled: bool with get, set
    abstract shadowMapType: ShadowMapType with get, set
    abstract shadowMapCullFace: CullFace with get, set
    abstract supportsFloatTextures: unit -> obj
    abstract supportsHalfFloatTextures: unit -> obj
    abstract supportsStandardDerivatives: unit -> obj
    abstract supportsCompressedTextureS3TC: unit -> obj
    abstract supportsCompressedTexturePVRTC: unit -> obj
    abstract supportsBlendMinMax: unit -> obj
    abstract supportsVertexTextures: unit -> obj
    abstract supportsInstancedArrays: unit -> obj
    abstract enableScissorTest: boolean:obj -> obj

/// The WebGL renderer displays your beautifully crafted scenes using WebGL, if your device supports it.
/// This renderer has way better performance than CanvasRenderer.
[<AllowNullLiteral>]
type WebGLRendererStatic =
    /// parameters is an optional object with properties defining the renderer's behaviour. The constructor also accepts no parameters at all. In all cases, it will assume sane defaults when parameters are missing.
    [<Emit "new $0($1...)">]
    abstract Create: ?parameters:WebGLRendererParameters -> WebGLRenderer










[<AllowNullLiteral>]
type WebGLRenderTargetOptions =
    abstract wrapS: Wrapping with get, set
    abstract wrapT: Wrapping with get, set
    abstract magFilter: TextureFilter with get, set
    abstract minFilter: TextureFilter with get, set
    abstract format: float with get, set
    abstract ``type``: TextureDataType with get, set
    abstract anisotropy: float with get, set
    abstract depthBuffer: bool with get, set
    abstract stencilBuffer: bool with get, set
    abstract generateMipmaps: bool with get, set
    abstract depthTexture: DepthTexture with get, set
    abstract encoding: TextureEncoding with get, set

[<AllowNullLiteral>]
type WebGLRenderTarget =
    inherit EventDispatcher
    abstract uuid: string with get, set
    abstract width: float with get, set
    abstract height: float with get, set
    abstract scissor: Vector4 with get, set
    abstract scissorTest: bool with get, set
    abstract viewport: Vector4 with get, set
    abstract texture: Texture with get, set
    abstract depthBuffer: bool with get, set
    abstract stencilBuffer: bool with get, set
    abstract depthTexture: DepthTexture with get, set
    abstract isWebGLRenderTarget: obj
    abstract wrapS: obj with get, set
    abstract wrapT: obj with get, set
    abstract magFilter: obj with get, set
    abstract minFilter: obj with get, set
    abstract anisotropy: obj with get, set
    abstract offset: obj with get, set
    abstract repeat: obj with get, set
    abstract format: obj with get, set
    abstract ``type``: obj with get, set
    abstract generateMipmaps: obj with get, set
    abstract setSize: width:float * height:float -> unit
    abstract clone: unit -> WebGLRenderTarget
    abstract copy: source:WebGLRenderTarget -> WebGLRenderTarget
    abstract dispose: unit -> unit

[<AllowNullLiteral>]
type WebGLRenderTargetStatic =
    [<Emit "new $0($1...)">]
    abstract Create: width:float * height:float * ?options:WebGLRenderTargetOptions -> WebGLRenderTarget



[<AllowNullLiteral>]
type IFog =
    abstract name: string with get, set
    abstract color: Color with get, set
    abstract clone: unit -> IFog
    abstract toJSON: unit -> obj

/// This class contains the parameters that define linear fog, i.e., that grows linearly denser with the distance.
[<AllowNullLiteral>]
type Fog =
    inherit IFog
    abstract name: string with get, set
    /// Fog color.
    abstract color: Color with get, set
    /// The minimum distance to start applying fog. Objects that are less than 'near' units from the active camera won't be affected by fog.
    abstract near: float with get, set
    /// The maximum distance at which fog stops being calculated and applied. Objects that are more than 'far' units away from the active camera won't be affected by fog.
    /// Default is 1000.
    abstract far: float with get, set
    abstract isFog: obj
    abstract clone: unit -> Fog
    abstract toJSON: unit -> obj

/// This class contains the parameters that define linear fog, i.e., that grows linearly denser with the distance.
[<AllowNullLiteral>]
type FogStatic =
    [<Emit "new $0($1...)">]
    abstract Create: color:U3<Color, float, string> * ?near:float * ?far:float -> Fog




/// This class contains the parameters that define linear fog, i.e., that grows exponentially denser with the distance.
[<AllowNullLiteral>]
type FogExp2 =
    inherit IFog
    abstract name: string with get, set
    abstract color: Color with get, set
    /// Defines how fast the fog will grow dense.
    /// Default is 0.00025.
    abstract density: float with get, set
    abstract isFogExp2: obj
    abstract clone: unit -> FogExp2
    abstract toJSON: unit -> obj

/// This class contains the parameters that define linear fog, i.e., that grows exponentially denser with the distance.
[<AllowNullLiteral>]
type FogExp2Static =
    [<Emit "new $0($1...)">]
    abstract Create: hex:U2<float, string> * ?density:float -> FogExp2











/// Scenes allow you to set up what and where is to be rendered by three.js. This is where you place objects, lights and cameras.
[<AllowNullLiteral>]
type Scene =
    inherit Object3D
    abstract ``type``: string with get, set
    /// A fog instance defining the type of fog that affects everything rendered in the scene. Default is null.
    abstract fog: IFog with get, set
    /// If not null, it will force everything in the scene to be rendered with that material. Default is null.
    abstract overrideMaterial: Material with get, set
    abstract autoUpdate: bool with get, set
    abstract background: U3<Color, Texture, WebGLCubeRenderTarget> with get, set
    abstract environment: Texture with get, set
    abstract isScene: obj
    /// Calls before rendering scene
    abstract onBeforeRender: (WebGLRenderer -> Scene -> Camera -> U2<WebGLRenderTarget, obj> -> unit) with get, set
    /// Calls after rendering scene
    abstract onAfterRender: (WebGLRenderer -> Scene -> Camera -> unit) with get, set
    abstract toJSON: ?meta:obj -> obj
    abstract dispose: unit -> unit

/// Scenes allow you to set up what and where is to be rendered by three.js. This is where you place objects, lights and cameras.
[<AllowNullLiteral>]
type SceneStatic =
    [<Emit "new $0($1...)">]
    abstract Create: unit -> Scene








[<AllowNullLiteral>]
type CanvasTexture =
    inherit Texture

[<AllowNullLiteral>]
type CanvasTextureStatic =
    [<Emit "new $0($1...)">]
    abstract Create: canvas:U3<HTMLImageElement, HTMLCanvasElement, HTMLVideoElement>
                     * ?mapping:Mapping
                     * ?wrapS:Wrapping
                     * ?wrapT:Wrapping
                     * ?magFilter:TextureFilter
                     * ?minFilter:TextureFilter
                     * ?format:PixelFormat
                     * ?``type``:TextureDataType
                     * ?anisotropy:float
                     -> CanvasTexture









[<AllowNullLiteral>]
type CompressedTexture =
    inherit Texture
    abstract image: CompressedTextureImage with get, set

[<AllowNullLiteral>]
type CompressedTextureStatic =
    [<Emit "new $0($1...)">]
    abstract Create: mipmaps:ResizeArray<ImageData>
                     * width:float
                     * height:float
                     * ?format:CompressedPixelFormat
                     * ?``type``:TextureDataType
                     * ?mapping:Mapping
                     * ?wrapS:Wrapping
                     * ?wrapT:Wrapping
                     * ?magFilter:TextureFilter
                     * ?minFilter:TextureFilter
                     * ?anisotropy:float
                     * ?encoding:TextureEncoding
                     -> CompressedTexture

[<AllowNullLiteral>]
type CompressedTextureImage =
    abstract width: float with get, set
    abstract height: float with get, set









[<AllowNullLiteral>]
type CubeTexture =
    inherit Texture
    abstract images: obj with get, set

[<AllowNullLiteral>]
type CubeTextureStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?images:ResizeArray<obj>
                     * ?mapping:Mapping
                     * ?wrapS:Wrapping
                     * ?wrapT:Wrapping
                     * ?magFilter:TextureFilter
                     * ?minFilter:TextureFilter
                     * ?format:PixelFormat
                     * ?``type``:TextureDataType
                     * ?anisotropy:float
                     * ?encoding:TextureEncoding
                     -> CubeTexture










[<AllowNullLiteral>]
type DataTexture =
    inherit Texture
    abstract image: ImageData with get, set

[<AllowNullLiteral>]
type DataTextureStatic =
    [<Emit "new $0($1...)">]
    abstract Create: data:TypedArray
                     * width:float
                     * height:float
                     * ?format:PixelFormat
                     * ?``type``:TextureDataType
                     * ?mapping:Mapping
                     * ?wrapS:Wrapping
                     * ?wrapT:Wrapping
                     * ?magFilter:TextureFilter
                     * ?minFilter:TextureFilter
                     * ?anisotropy:float
                     * ?encoding:TextureEncoding
                     -> DataTexture




[<AllowNullLiteral>]
type DataTexture2DArray =
    inherit Texture

[<AllowNullLiteral>]
type DataTexture2DArrayStatic =
    [<Emit "new $0($1...)">]
    abstract Create: data:TypedArray * width:float * height:float * depth:float -> DataTexture2DArray




[<AllowNullLiteral>]
type DataTexture3D =
    inherit Texture

[<AllowNullLiteral>]
type DataTexture3DStatic =
    [<Emit "new $0($1...)">]
    abstract Create: data:TypedArray * width:float * height:float * depth:float -> DataTexture3D







[<AllowNullLiteral>]
type DepthTexture =
    inherit Texture
    abstract image: DepthTextureImage with get, set

[<AllowNullLiteral>]
type DepthTextureStatic =
    [<Emit "new $0($1...)">]
    abstract Create: width:float
                     * heighht:float
                     * ?``type``:TextureDataType
                     * ?mapping:Mapping
                     * ?wrapS:Wrapping
                     * ?wrapT:Wrapping
                     * ?magFilter:TextureFilter
                     * ?minFilter:TextureFilter
                     * ?anisotropy:float
                     -> DepthTexture

[<AllowNullLiteral>]
type DepthTextureImage =
    abstract width: float with get, set
    abstract height: float with get, set










[<Import("TextureIdCount", "three")>]
let TextureIdCount: float = jsNative


[<AllowNullLiteral>]
type Texture =
    inherit EventDispatcher
    abstract id: float with get, set
    abstract uuid: string with get, set
    abstract name: string with get, set
    abstract sourceFile: string with get, set
    abstract image: obj with get, set
    abstract mipmaps: ResizeArray<obj> with get, set
    abstract mapping: Mapping with get, set
    abstract wrapS: Wrapping with get, set
    abstract wrapT: Wrapping with get, set
    abstract magFilter: TextureFilter with get, set
    abstract minFilter: TextureFilter with get, set
    abstract anisotropy: float with get, set
    abstract format: PixelFormat with get, set
    abstract internalFormat: PixelFormatGPU with get, set
    abstract ``type``: TextureDataType with get, set
    abstract matrix: Matrix3 with get, set
    abstract matrixAutoUpdate: bool with get, set
    abstract offset: Vector2 with get, set
    abstract repeat: Vector2 with get, set
    abstract center: Vector2 with get, set
    abstract rotation: float with get, set
    abstract generateMipmaps: bool with get, set
    abstract premultiplyAlpha: bool with get, set
    abstract flipY: bool with get, set
    abstract unpackAlignment: float with get, set
    abstract encoding: TextureEncoding with get, set
    abstract version: float with get, set
    abstract needsUpdate: bool with get, set
    abstract isTexture: obj
    abstract onUpdate: (unit -> unit) with get, set
    abstract clone: unit -> Texture
    abstract copy: source:Texture -> Texture
    abstract toJSON: meta:obj -> obj
    abstract dispose: unit -> unit
    abstract transformUv: uv:Vector2 -> Vector2
    abstract updateMatrix: unit -> unit

[<AllowNullLiteral>]
type TextureStatic =
    [<Emit "new $0($1...)">]
    abstract Create: ?image:U3<HTMLImageElement, HTMLCanvasElement, HTMLVideoElement>
                     * ?mapping:Mapping
                     * ?wrapS:Wrapping
                     * ?wrapT:Wrapping
                     * ?magFilter:TextureFilter
                     * ?minFilter:TextureFilter
                     * ?format:PixelFormat
                     * ?``type``:TextureDataType
                     * ?anisotropy:float
                     * ?encoding:TextureEncoding
                     -> Texture

    abstract DEFAULT_IMAGE: obj with get, set
    abstract DEFAULT_MAPPING: obj with get, set








[<AllowNullLiteral>]
type VideoTexture =
    inherit Texture
    abstract isVideoTexture: obj

[<AllowNullLiteral>]
type VideoTextureStatic =
    [<Emit "new $0($1...)">]
    abstract Create: video:HTMLVideoElement
                     * ?mapping:Mapping
                     * ?wrapS:Wrapping
                     * ?wrapT:Wrapping
                     * ?magFilter:TextureFilter
                     * ?minFilter:TextureFilter
                     * ?format:PixelFormat
                     * ?``type``:TextureDataType
                     * ?anisotropy:float
                     -> VideoTexture

[<Import("REVISION", "three")>]
let REVISION: string = jsNative

[<Import("CullFaceNone", "three")>]
let CullFaceNone: CullFace = jsNative

[<Import("CullFaceBack", "three")>]
let CullFaceBack: CullFace = jsNative

[<Import("CullFaceFront", "three")>]
let CullFaceFront: CullFace = jsNative

[<Import("CullFaceFrontBack", "three")>]
let CullFaceFrontBack: CullFace = jsNative

[<Import("FrontFaceDirectionCW", "three")>]
let FrontFaceDirectionCW: FrontFaceDirection = jsNative

[<Import("FrontFaceDirectionCCW", "three")>]
let FrontFaceDirectionCCW: FrontFaceDirection = jsNative

[<Import("BasicShadowMap", "three")>]
let BasicShadowMap: ShadowMapType = jsNative

[<Import("PCFShadowMap", "three")>]
let PCFShadowMap: ShadowMapType = jsNative

[<Import("PCFSoftShadowMap", "three")>]
let PCFSoftShadowMap: ShadowMapType = jsNative

[<Import("VSMShadowMap", "three")>]
let VSMShadowMap: ShadowMapType = jsNative

[<Import("FrontSide", "three")>]
let FrontSide: Side = jsNative

[<Import("BackSide", "three")>]
let BackSide: Side = jsNative

[<Import("DoubleSide", "three")>]
let DoubleSide: Side = jsNative

[<Import("FlatShading", "three")>]
let FlatShading: Shading = jsNative

[<Import("SmoothShading", "three")>]
let SmoothShading: Shading = jsNative

[<Import("NoBlending", "three")>]
let NoBlending: Blending = jsNative

[<Import("NormalBlending", "three")>]
let NormalBlending: Blending = jsNative

[<Import("AdditiveBlending", "three")>]
let AdditiveBlending: Blending = jsNative

[<Import("SubtractiveBlending", "three")>]
let SubtractiveBlending: Blending = jsNative

[<Import("MultiplyBlending", "three")>]
let MultiplyBlending: Blending = jsNative

[<Import("CustomBlending", "three")>]
let CustomBlending: Blending = jsNative

[<Import("AddEquation", "three")>]
let AddEquation: BlendingEquation = jsNative

[<Import("SubtractEquation", "three")>]
let SubtractEquation: BlendingEquation = jsNative

[<Import("ReverseSubtractEquation", "three")>]
let ReverseSubtractEquation: BlendingEquation = jsNative

[<Import("MinEquation", "three")>]
let MinEquation: BlendingEquation = jsNative

[<Import("MaxEquation", "three")>]
let MaxEquation: BlendingEquation = jsNative

[<Import("ZeroFactor", "three")>]
let ZeroFactor: BlendingDstFactor = jsNative

[<Import("OneFactor", "three")>]
let OneFactor: BlendingDstFactor = jsNative

[<Import("SrcColorFactor", "three")>]
let SrcColorFactor: BlendingDstFactor = jsNative

[<Import("OneMinusSrcColorFactor", "three")>]
let OneMinusSrcColorFactor: BlendingDstFactor = jsNative

[<Import("SrcAlphaFactor", "three")>]
let SrcAlphaFactor: BlendingDstFactor = jsNative

[<Import("OneMinusSrcAlphaFactor", "three")>]
let OneMinusSrcAlphaFactor: BlendingDstFactor = jsNative

[<Import("DstAlphaFactor", "three")>]
let DstAlphaFactor: BlendingDstFactor = jsNative

[<Import("OneMinusDstAlphaFactor", "three")>]
let OneMinusDstAlphaFactor: BlendingDstFactor = jsNative

[<Import("DstColorFactor", "three")>]
let DstColorFactor: BlendingDstFactor = jsNative

[<Import("OneMinusDstColorFactor", "three")>]
let OneMinusDstColorFactor: BlendingDstFactor = jsNative

[<Import("SrcAlphaSaturateFactor", "three")>]
let SrcAlphaSaturateFactor: BlendingSrcFactor = jsNative

[<Import("NeverDepth", "three")>]
let NeverDepth: DepthModes = jsNative

[<Import("AlwaysDepth", "three")>]
let AlwaysDepth: DepthModes = jsNative

[<Import("LessDepth", "three")>]
let LessDepth: DepthModes = jsNative

[<Import("LessEqualDepth", "three")>]
let LessEqualDepth: DepthModes = jsNative

[<Import("EqualDepth", "three")>]
let EqualDepth: DepthModes = jsNative

[<Import("GreaterEqualDepth", "three")>]
let GreaterEqualDepth: DepthModes = jsNative

[<Import("GreaterDepth", "three")>]
let GreaterDepth: DepthModes = jsNative

[<Import("NotEqualDepth", "three")>]
let NotEqualDepth: DepthModes = jsNative

[<Import("MultiplyOperation", "three")>]
let MultiplyOperation: Combine = jsNative

[<Import("MixOperation", "three")>]
let MixOperation: Combine = jsNative

[<Import("AddOperation", "three")>]
let AddOperation: Combine = jsNative

[<Import("NoToneMapping", "three")>]
let NoToneMapping: ToneMapping = jsNative

[<Import("LinearToneMapping", "three")>]
let LinearToneMapping: ToneMapping = jsNative

[<Import("ReinhardToneMapping", "three")>]
let ReinhardToneMapping: ToneMapping = jsNative

[<Import("CineonToneMapping", "three")>]
let CineonToneMapping: ToneMapping = jsNative

[<Import("ACESFilmicToneMapping", "three")>]
let ACESFilmicToneMapping: ToneMapping = jsNative

[<Import("UVMapping", "three")>]
let UVMapping: Mapping = jsNative

[<Import("CubeReflectionMapping", "three")>]
let CubeReflectionMapping: Mapping = jsNative

[<Import("CubeRefractionMapping", "three")>]
let CubeRefractionMapping: Mapping = jsNative

[<Import("EquirectangularReflectionMapping", "three")>]
let EquirectangularReflectionMapping: Mapping = jsNative

[<Import("EquirectangularRefractionMapping", "three")>]
let EquirectangularRefractionMapping: Mapping = jsNative

[<Import("CubeUVReflectionMapping", "three")>]
let CubeUVReflectionMapping: Mapping = jsNative

[<Import("CubeUVRefractionMapping", "three")>]
let CubeUVRefractionMapping: Mapping = jsNative

[<Import("RepeatWrapping", "three")>]
let RepeatWrapping: Wrapping = jsNative

[<Import("ClampToEdgeWrapping", "three")>]
let ClampToEdgeWrapping: Wrapping = jsNative

[<Import("MirroredRepeatWrapping", "three")>]
let MirroredRepeatWrapping: Wrapping = jsNative

[<Import("NearestFilter", "three")>]
let NearestFilter: TextureFilter = jsNative

[<Import("NearestMipmapNearestFilter", "three")>]
let NearestMipmapNearestFilter: TextureFilter = jsNative

[<Import("NearestMipMapNearestFilter", "three")>]
let NearestMipMapNearestFilter: TextureFilter = jsNative

[<Import("NearestMipmapLinearFilter", "three")>]
let NearestMipmapLinearFilter: TextureFilter = jsNative

[<Import("NearestMipMapLinearFilter", "three")>]
let NearestMipMapLinearFilter: TextureFilter = jsNative

[<Import("LinearFilter", "three")>]
let LinearFilter: TextureFilter = jsNative

[<Import("LinearMipmapNearestFilter", "three")>]
let LinearMipmapNearestFilter: TextureFilter = jsNative

[<Import("LinearMipMapNearestFilter", "three")>]
let LinearMipMapNearestFilter: TextureFilter = jsNative

[<Import("LinearMipmapLinearFilter", "three")>]
let LinearMipmapLinearFilter: TextureFilter = jsNative

[<Import("LinearMipMapLinearFilter", "three")>]
let LinearMipMapLinearFilter: TextureFilter = jsNative

[<Import("UnsignedByteType", "three")>]
let UnsignedByteType: TextureDataType = jsNative

[<Import("ByteType", "three")>]
let ByteType: TextureDataType = jsNative

[<Import("ShortType", "three")>]
let ShortType: TextureDataType = jsNative

[<Import("UnsignedShortType", "three")>]
let UnsignedShortType: TextureDataType = jsNative

[<Import("IntType", "three")>]
let IntType: TextureDataType = jsNative

[<Import("UnsignedIntType", "three")>]
let UnsignedIntType: TextureDataType = jsNative

[<Import("FloatType", "three")>]
let FloatType: TextureDataType = jsNative

[<Import("HalfFloatType", "three")>]
let HalfFloatType: TextureDataType = jsNative

[<Import("UnsignedShort4444Type", "three")>]
let UnsignedShort4444Type: TextureDataType = jsNative

[<Import("UnsignedShort5551Type", "three")>]
let UnsignedShort5551Type: TextureDataType = jsNative

[<Import("UnsignedShort565Type", "three")>]
let UnsignedShort565Type: TextureDataType = jsNative

[<Import("UnsignedInt248Type", "three")>]
let UnsignedInt248Type: TextureDataType = jsNative

[<Import("AlphaFormat", "three")>]
let AlphaFormat: PixelFormat = jsNative

[<Import("RGBFormat", "three")>]
let RGBFormat: PixelFormat = jsNative

[<Import("RGBAFormat", "three")>]
let RGBAFormat: PixelFormat = jsNative

[<Import("LuminanceFormat", "three")>]
let LuminanceFormat: PixelFormat = jsNative

[<Import("LuminanceAlphaFormat", "three")>]
let LuminanceAlphaFormat: PixelFormat = jsNative

[<Import("RGBEFormat", "three")>]
let RGBEFormat: PixelFormat = jsNative

[<Import("DepthFormat", "three")>]
let DepthFormat: PixelFormat = jsNative

[<Import("DepthStencilFormat", "three")>]
let DepthStencilFormat: PixelFormat = jsNative

[<Import("RedFormat", "three")>]
let RedFormat: PixelFormat = jsNative

[<Import("RedIntegerFormat", "three")>]
let RedIntegerFormat: PixelFormat = jsNative

[<Import("RGFormat", "three")>]
let RGFormat: PixelFormat = jsNative

[<Import("RGIntegerFormat", "three")>]
let RGIntegerFormat: PixelFormat = jsNative

[<Import("RGBIntegerFormat", "three")>]
let RGBIntegerFormat: PixelFormat = jsNative

[<Import("RGBAIntegerFormat", "three")>]
let RGBAIntegerFormat: PixelFormat = jsNative

[<Import("RGB_S3TC_DXT1_Format", "three")>]
let RGB_S3TC_DXT1_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_S3TC_DXT1_Format", "three")>]
let RGBA_S3TC_DXT1_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_S3TC_DXT3_Format", "three")>]
let RGBA_S3TC_DXT3_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_S3TC_DXT5_Format", "three")>]
let RGBA_S3TC_DXT5_Format: CompressedPixelFormat = jsNative

[<Import("RGB_PVRTC_4BPPV1_Format", "three")>]
let RGB_PVRTC_4BPPV1_Format: CompressedPixelFormat = jsNative

[<Import("RGB_PVRTC_2BPPV1_Format", "three")>]
let RGB_PVRTC_2BPPV1_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_PVRTC_4BPPV1_Format", "three")>]
let RGBA_PVRTC_4BPPV1_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_PVRTC_2BPPV1_Format", "three")>]
let RGBA_PVRTC_2BPPV1_Format: CompressedPixelFormat = jsNative

[<Import("RGB_ETC1_Format", "three")>]
let RGB_ETC1_Format: CompressedPixelFormat = jsNative

[<Import("RGB_ETC2_Format", "three")>]
let RGB_ETC2_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ETC2_EAC_Format", "three")>]
let RGBA_ETC2_EAC_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_4x4_Format", "three")>]
let RGBA_ASTC_4x4_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_5x4_Format", "three")>]
let RGBA_ASTC_5x4_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_5x5_Format", "three")>]
let RGBA_ASTC_5x5_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_6x5_Format", "three")>]
let RGBA_ASTC_6x5_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_6x6_Format", "three")>]
let RGBA_ASTC_6x6_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_8x5_Format", "three")>]
let RGBA_ASTC_8x5_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_8x6_Format", "three")>]
let RGBA_ASTC_8x6_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_8x8_Format", "three")>]
let RGBA_ASTC_8x8_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_10x5_Format", "three")>]
let RGBA_ASTC_10x5_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_10x6_Format", "three")>]
let RGBA_ASTC_10x6_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_10x8_Format", "three")>]
let RGBA_ASTC_10x8_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_10x10_Format", "three")>]
let RGBA_ASTC_10x10_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_12x10_Format", "three")>]
let RGBA_ASTC_12x10_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_ASTC_12x12_Format", "three")>]
let RGBA_ASTC_12x12_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_4x4_Format", "three")>]
let SRGB8_ALPHA8_ASTC_4x4_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_5x4_Format", "three")>]
let SRGB8_ALPHA8_ASTC_5x4_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_5x5_Format", "three")>]
let SRGB8_ALPHA8_ASTC_5x5_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_6x5_Format", "three")>]
let SRGB8_ALPHA8_ASTC_6x5_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_6x6_Format", "three")>]
let SRGB8_ALPHA8_ASTC_6x6_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_8x5_Format", "three")>]
let SRGB8_ALPHA8_ASTC_8x5_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_8x6_Format", "three")>]
let SRGB8_ALPHA8_ASTC_8x6_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_8x8_Format", "three")>]
let SRGB8_ALPHA8_ASTC_8x8_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_10x5_Format", "three")>]
let SRGB8_ALPHA8_ASTC_10x5_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_10x6_Format", "three")>]
let SRGB8_ALPHA8_ASTC_10x6_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_10x8_Format", "three")>]
let SRGB8_ALPHA8_ASTC_10x8_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_10x10_Format", "three")>]
let SRGB8_ALPHA8_ASTC_10x10_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_12x10_Format", "three")>]
let SRGB8_ALPHA8_ASTC_12x10_Format: CompressedPixelFormat = jsNative

[<Import("SRGB8_ALPHA8_ASTC_12x12_Format", "three")>]
let SRGB8_ALPHA8_ASTC_12x12_Format: CompressedPixelFormat = jsNative

[<Import("RGBA_BPTC_Format", "three")>]
let RGBA_BPTC_Format: CompressedPixelFormat = jsNative

[<Import("LoopOnce", "three")>]
let LoopOnce: AnimationActionLoopStyles = jsNative

[<Import("LoopRepeat", "three")>]
let LoopRepeat: AnimationActionLoopStyles = jsNative

[<Import("LoopPingPong", "three")>]
let LoopPingPong: AnimationActionLoopStyles = jsNative

[<Import("InterpolateDiscrete", "three")>]
let InterpolateDiscrete: InterpolationModes = jsNative

[<Import("InterpolateLinear", "three")>]
let InterpolateLinear: InterpolationModes = jsNative

[<Import("InterpolateSmooth", "three")>]
let InterpolateSmooth: InterpolationModes = jsNative

[<Import("ZeroCurvatureEnding", "three")>]
let ZeroCurvatureEnding: InterpolationEndingModes = jsNative

[<Import("ZeroSlopeEnding", "three")>]
let ZeroSlopeEnding: InterpolationEndingModes = jsNative

[<Import("WrapAroundEnding", "three")>]
let WrapAroundEnding: InterpolationEndingModes = jsNative

[<Import("NormalAnimationBlendMode", "three")>]
let NormalAnimationBlendMode: AnimationBlendMode = jsNative

[<Import("AdditiveAnimationBlendMode", "three")>]
let AdditiveAnimationBlendMode: AnimationBlendMode = jsNative

[<Import("TrianglesDrawMode", "three")>]
let TrianglesDrawMode: TrianglesDrawModes = jsNative

[<Import("TriangleStripDrawMode", "three")>]
let TriangleStripDrawMode: TrianglesDrawModes = jsNative

[<Import("TriangleFanDrawMode", "three")>]
let TriangleFanDrawMode: TrianglesDrawModes = jsNative

[<Import("LinearEncoding", "three")>]
let LinearEncoding: TextureEncoding = jsNative

[<Import("sRGBEncoding", "three")>]
let sRGBEncoding: TextureEncoding = jsNative

[<Import("GammaEncoding", "three")>]
let GammaEncoding: TextureEncoding = jsNative

[<Import("RGBEEncoding", "three")>]
let RGBEEncoding: TextureEncoding = jsNative

[<Import("LogLuvEncoding", "three")>]
let LogLuvEncoding: TextureEncoding = jsNative

[<Import("RGBM7Encoding", "three")>]
let RGBM7Encoding: TextureEncoding = jsNative

[<Import("RGBM16Encoding", "three")>]
let RGBM16Encoding: TextureEncoding = jsNative

[<Import("RGBDEncoding", "three")>]
let RGBDEncoding: TextureEncoding = jsNative

[<Import("BasicDepthPacking", "three")>]
let BasicDepthPacking: DepthPackingStrategies = jsNative

[<Import("RGBADepthPacking", "three")>]
let RGBADepthPacking: DepthPackingStrategies = jsNative

[<Import("TangentSpaceNormalMap", "three")>]
let TangentSpaceNormalMap: NormalMapTypes = jsNative

[<Import("ObjectSpaceNormalMap", "three")>]
let ObjectSpaceNormalMap: NormalMapTypes = jsNative

[<Import("ZeroStencilOp", "three")>]
let ZeroStencilOp: StencilOp = jsNative

[<Import("KeepStencilOp", "three")>]
let KeepStencilOp: StencilOp = jsNative

[<Import("ReplaceStencilOp", "three")>]
let ReplaceStencilOp: StencilOp = jsNative

[<Import("IncrementStencilOp", "three")>]
let IncrementStencilOp: StencilOp = jsNative

[<Import("DecrementStencilOp", "three")>]
let DecrementStencilOp: StencilOp = jsNative

[<Import("IncrementWrapStencilOp", "three")>]
let IncrementWrapStencilOp: StencilOp = jsNative

[<Import("DecrementWrapStencilOp", "three")>]
let DecrementWrapStencilOp: StencilOp = jsNative

[<Import("InvertStencilOp", "three")>]
let InvertStencilOp: StencilOp = jsNative

[<Import("NeverStencilFunc", "three")>]
let NeverStencilFunc: StencilFunc = jsNative

[<Import("LessStencilFunc", "three")>]
let LessStencilFunc: StencilFunc = jsNative

[<Import("EqualStencilFunc", "three")>]
let EqualStencilFunc: StencilFunc = jsNative

[<Import("LessEqualStencilFunc", "three")>]
let LessEqualStencilFunc: StencilFunc = jsNative

[<Import("GreaterStencilFunc", "three")>]
let GreaterStencilFunc: StencilFunc = jsNative

[<Import("NotEqualStencilFunc", "three")>]
let NotEqualStencilFunc: StencilFunc = jsNative

[<Import("GreaterEqualStencilFunc", "three")>]
let GreaterEqualStencilFunc: StencilFunc = jsNative

[<Import("AlwaysStencilFunc", "three")>]
let AlwaysStencilFunc: StencilFunc = jsNative

[<Import("StaticDrawUsage", "three")>]
let StaticDrawUsage: Usage = jsNative

[<Import("DynamicDrawUsage", "three")>]
let DynamicDrawUsage: Usage = jsNative

[<Import("StreamDrawUsage", "three")>]
let StreamDrawUsage: Usage = jsNative

[<Import("StaticReadUsage", "three")>]
let StaticReadUsage: Usage = jsNative

[<Import("DynamicReadUsage", "three")>]
let DynamicReadUsage: Usage = jsNative

[<Import("StreamReadUsage", "three")>]
let StreamReadUsage: Usage = jsNative

[<Import("StaticCopyUsage", "three")>]
let StaticCopyUsage: Usage = jsNative

[<Import("DynamicCopyUsage", "three")>]
let DynamicCopyUsage: Usage = jsNative

[<Import("StreamCopyUsage", "three")>]
let StreamCopyUsage: Usage = jsNative

type MOUSE = obj

type TOUCH = obj

[<RequireQualifiedAccess>]
type CullFace = obj

[<RequireQualifiedAccess>]
type FrontFaceDirection = obj

[<RequireQualifiedAccess>]
type ShadowMapType = obj

[<RequireQualifiedAccess>]
type Side = obj

[<RequireQualifiedAccess>]
type Shading = obj

[<RequireQualifiedAccess>]
type Blending = obj

[<RequireQualifiedAccess>]
type BlendingEquation = obj

[<RequireQualifiedAccess>]
type BlendingDstFactor = obj

[<RequireQualifiedAccess>]
type BlendingSrcFactor = obj

[<RequireQualifiedAccess>]
type DepthModes = obj

[<RequireQualifiedAccess>]
type Combine = obj

[<RequireQualifiedAccess>]
type ToneMapping = obj

[<RequireQualifiedAccess>]
type Mapping = obj

[<RequireQualifiedAccess>]
type Wrapping = obj

[<RequireQualifiedAccess>]
type TextureFilter = obj

[<RequireQualifiedAccess>]
type TextureDataType = obj

[<RequireQualifiedAccess>]
type PixelFormat = obj

[<StringEnum>]
[<RequireQualifiedAccess>]
type PixelFormatGPU =
    | [<CompiledName "ALPHA">] ALPHA
    | [<CompiledName "RGB">] RGB
    | [<CompiledName "RGBA">] RGBA
    | [<CompiledName "LUMINANCE">] LUMINANCE
    | [<CompiledName "LUMINANCE_ALPHA">] LUMINANCE_ALPHA
    | [<CompiledName "RED_INTEGER">] RED_INTEGER
    | [<CompiledName "R8">] R8
    | [<CompiledName "R8_SNORM">] R8_SNORM
    | [<CompiledName "R8I">] R8I
    | [<CompiledName "R8UI">] R8UI
    | [<CompiledName "R16I">] R16I
    | [<CompiledName "R16UI">] R16UI
    | [<CompiledName "R16F">] R16F
    | [<CompiledName "R32I">] R32I
    | [<CompiledName "R32UI">] R32UI
    | [<CompiledName "R32F">] R32F
    | [<CompiledName "RG8">] RG8
    | [<CompiledName "RG8_SNORM">] RG8_SNORM
    | [<CompiledName "RG8I">] RG8I
    | [<CompiledName "RG8UI">] RG8UI
    | [<CompiledName "RG16I">] RG16I
    | [<CompiledName "RG16UI">] RG16UI
    | [<CompiledName "RG16F">] RG16F
    | [<CompiledName "RG32I">] RG32I
    | [<CompiledName "RG32UI">] RG32UI
    | [<CompiledName "RG32F">] RG32F
    | [<CompiledName "RGB565">] RGB565
    | [<CompiledName "RGB8">] RGB8
    | [<CompiledName "RGB8_SNORM">] RGB8_SNORM
    | [<CompiledName "RGB8I">] RGB8I
    | [<CompiledName "RGB8UI">] RGB8UI
    | [<CompiledName "RGB16I">] RGB16I
    | [<CompiledName "RGB16UI">] RGB16UI
    | [<CompiledName "RGB16F">] RGB16F
    | [<CompiledName "RGB32I">] RGB32I
    | [<CompiledName "RGB32UI">] RGB32UI
    | [<CompiledName "RGB32F">] RGB32F
    | [<CompiledName "RGB9_E5">] RGB9_E5
    | [<CompiledName "SRGB8">] SRGB8
    | [<CompiledName "R11F_G11F_B10F">] R11F_G11F_B10F
    | [<CompiledName "RGBA4">] RGBA4
    | [<CompiledName "RGBA8">] RGBA8
    | [<CompiledName "RGBA8_SNORM">] RGBA8_SNORM
    | [<CompiledName "RGBA8I">] RGBA8I
    | [<CompiledName "RGBA8UI">] RGBA8UI
    | [<CompiledName "RGBA16I">] RGBA16I
    | [<CompiledName "RGBA16UI">] RGBA16UI
    | [<CompiledName "RGBA16F">] RGBA16F
    | [<CompiledName "RGBA32I">] RGBA32I
    | [<CompiledName "RGBA32UI">] RGBA32UI
    | [<CompiledName "RGBA32F">] RGBA32F
    | [<CompiledName "RGB5_A1">] RGB5_A1
    | [<CompiledName "RGB10_A2">] RGB10_A2
    | [<CompiledName "RGB10_A2UI">] RGB10_A2UI
    | [<CompiledName "SRGB8_ALPHA8">] SRGB8_ALPHA8
    | [<CompiledName "DEPTH_COMPONENT16">] DEPTH_COMPONENT16
    | [<CompiledName "DEPTH_COMPONENT24">] DEPTH_COMPONENT24
    | [<CompiledName "DEPTH_COMPONENT32F">] DEPTH_COMPONENT32F
    | [<CompiledName "DEPTH24_STENCIL8">] DEPTH24_STENCIL8
    | [<CompiledName "DEPTH32F_STENCIL8">] DEPTH32F_STENCIL8

[<RequireQualifiedAccess>]
type CompressedPixelFormat = obj

[<RequireQualifiedAccess>]
type AnimationActionLoopStyles = obj

[<RequireQualifiedAccess>]
type InterpolationModes = obj

[<RequireQualifiedAccess>]
type InterpolationEndingModes = obj

[<RequireQualifiedAccess>]
type AnimationBlendMode = obj

[<RequireQualifiedAccess>]
type TrianglesDrawModes = obj

[<RequireQualifiedAccess>]
type TextureEncoding = obj

[<RequireQualifiedAccess>]
type DepthPackingStrategies = obj

[<RequireQualifiedAccess>]
type NormalMapTypes = obj

[<RequireQualifiedAccess>]
type StencilOp = obj

[<RequireQualifiedAccess>]
type StencilFunc = obj

[<RequireQualifiedAccess>]
type Usage = obj


type TypedArray = obj
