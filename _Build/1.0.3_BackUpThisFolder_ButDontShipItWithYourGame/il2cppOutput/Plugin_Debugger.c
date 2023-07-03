#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





#if IL2CPP_MONO_DEBUGGER
static const Il2CppMethodExecutionContextInfo g_methodExecutionContextInfos[6] = 
{
	{ 15437, 0,  2 } /*tableIndex: 0 */,
	{ 17014, 1,  3 } /*tableIndex: 1 */,
	{ 10614, 2,  3 } /*tableIndex: 2 */,
	{ 17014, 3,  4 } /*tableIndex: 3 */,
	{ 17014, 4,  4 } /*tableIndex: 4 */,
	{ 15437, 5,  5 } /*tableIndex: 5 */,
};
#else
static const Il2CppMethodExecutionContextInfo g_methodExecutionContextInfos[1] = { { 0, 0, 0 } };
#endif
#if IL2CPP_MONO_DEBUGGER
static const char* g_methodExecutionContextInfoStrings[6] = 
{
	"progress",
	"pos",
	"hitCollider",
	"curScreenPoint",
	"curPosition",
	"frame",
};
#else
static const char* g_methodExecutionContextInfoStrings[1] = { NULL };
#endif
#if IL2CPP_MONO_DEBUGGER
static const Il2CppMethodExecutionContextInfoIndex g_methodExecutionContextInfoIndexes[24] = 
{
	{ 0, 0 } /* 0x06000001 System.Void Knob::Start() */,
	{ 0, 0 } /* 0x06000002 System.Void Knob::OnMouseDown() */,
	{ 0, 0 } /* 0x06000003 System.Void Knob::OnMouseUp() */,
	{ 0, 0 } /* 0x06000004 System.Void Knob::OnMouseDrag() */,
	{ 0, 0 } /* 0x06000005 System.Void Knob::.ctor() */,
	{ 0, 0 } /* 0x06000006 System.Void MyVideoPlayer::Start() */,
	{ 0, 3 } /* 0x06000007 System.Void MyVideoPlayer::Update() */,
	{ 0, 0 } /* 0x06000008 System.Void MyVideoPlayer::KnobOnPressDown() */,
	{ 0, 0 } /* 0x06000009 System.Void MyVideoPlayer::KnobOnRelease() */,
	{ 0, 0 } /* 0x0600000A System.Collections.IEnumerator MyVideoPlayer::DelayedSetVideoIsJumpingToFalse() */,
	{ 3, 2 } /* 0x0600000B System.Void MyVideoPlayer::KnobOnDrag() */,
	{ 0, 0 } /* 0x0600000C System.Void MyVideoPlayer::SetVideoIsJumpingToFalse() */,
	{ 0, 0 } /* 0x0600000D System.Void MyVideoPlayer::CalcKnobSimpleValue() */,
	{ 5, 1 } /* 0x0600000E System.Void MyVideoPlayer::VideoJump() */,
	{ 0, 0 } /* 0x0600000F System.Void MyVideoPlayer::BtnPlayVideo() */,
	{ 0, 0 } /* 0x06000010 System.Void MyVideoPlayer::VideoStop() */,
	{ 0, 0 } /* 0x06000011 System.Void MyVideoPlayer::VideoPlay() */,
	{ 0, 0 } /* 0x06000012 System.Void MyVideoPlayer::.ctor() */,
	{ 0, 0 } /* 0x06000013 System.Void MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::.ctor(System.Int32) */,
	{ 0, 0 } /* 0x06000014 System.Void MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::System.IDisposable.Dispose() */,
	{ 0, 0 } /* 0x06000015 System.Boolean MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::MoveNext() */,
	{ 0, 0 } /* 0x06000016 System.Object MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::System.Collections.Generic.IEnumerator<System.Object>.get_Current() */,
	{ 0, 0 } /* 0x06000017 System.Void MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::System.Collections.IEnumerator.Reset() */,
	{ 0, 0 } /* 0x06000018 System.Object MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::System.Collections.IEnumerator.get_Current() */,
};
#else
static const Il2CppMethodExecutionContextInfoIndex g_methodExecutionContextInfoIndexes[1] = { { 0, 0} };
#endif
#if IL2CPP_MONO_DEBUGGER
IL2CPP_EXTERN_C Il2CppSequencePoint g_sequencePointsPlugin[];
Il2CppSequencePoint g_sequencePointsPlugin[249] = 
{
	{ 50696, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 0 } /* seqPointIndex: 0 */,
	{ 50696, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 1 } /* seqPointIndex: 1 */,
	{ 50696, 1, 20, 20, 5, 6, 0, kSequencePointKind_Normal, 0, 2 } /* seqPointIndex: 2 */,
	{ 50696, 1, 21, 21, 9, 71, 1, kSequencePointKind_Normal, 0, 3 } /* seqPointIndex: 3 */,
	{ 50696, 1, 21, 21, 9, 71, 8, kSequencePointKind_StepOut, 0, 4 } /* seqPointIndex: 4 */,
	{ 50696, 1, 22, 22, 5, 6, 18, kSequencePointKind_Normal, 0, 5 } /* seqPointIndex: 5 */,
	{ 50697, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 6 } /* seqPointIndex: 6 */,
	{ 50697, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 7 } /* seqPointIndex: 7 */,
	{ 50697, 1, 25, 25, 5, 6, 0, kSequencePointKind_Normal, 0, 8 } /* seqPointIndex: 8 */,
	{ 50697, 1, 26, 26, 9, 45, 1, kSequencePointKind_Normal, 0, 9 } /* seqPointIndex: 9 */,
	{ 50697, 1, 26, 26, 9, 45, 7, kSequencePointKind_StepOut, 0, 10 } /* seqPointIndex: 10 */,
	{ 50697, 1, 27, 27, 5, 6, 13, kSequencePointKind_Normal, 0, 11 } /* seqPointIndex: 11 */,
	{ 50698, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 12 } /* seqPointIndex: 12 */,
	{ 50698, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 13 } /* seqPointIndex: 13 */,
	{ 50698, 1, 30, 30, 5, 6, 0, kSequencePointKind_Normal, 0, 14 } /* seqPointIndex: 14 */,
	{ 50698, 1, 31, 31, 9, 43, 1, kSequencePointKind_Normal, 0, 15 } /* seqPointIndex: 15 */,
	{ 50698, 1, 31, 31, 9, 43, 7, kSequencePointKind_StepOut, 0, 16 } /* seqPointIndex: 16 */,
	{ 50698, 1, 32, 32, 5, 6, 13, kSequencePointKind_Normal, 0, 17 } /* seqPointIndex: 17 */,
	{ 50699, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 18 } /* seqPointIndex: 18 */,
	{ 50699, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 19 } /* seqPointIndex: 19 */,
	{ 50699, 1, 35, 35, 5, 6, 0, kSequencePointKind_Normal, 0, 20 } /* seqPointIndex: 20 */,
	{ 50699, 1, 36, 36, 9, 40, 1, kSequencePointKind_Normal, 0, 21 } /* seqPointIndex: 21 */,
	{ 50699, 1, 36, 36, 9, 40, 7, kSequencePointKind_StepOut, 0, 22 } /* seqPointIndex: 22 */,
	{ 50699, 1, 37, 37, 5, 6, 13, kSequencePointKind_Normal, 0, 23 } /* seqPointIndex: 23 */,
	{ 50701, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 24 } /* seqPointIndex: 24 */,
	{ 50701, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 25 } /* seqPointIndex: 25 */,
	{ 50701, 2, 29, 29, 5, 6, 0, kSequencePointKind_Normal, 0, 26 } /* seqPointIndex: 26 */,
	{ 50701, 2, 30, 30, 9, 51, 1, kSequencePointKind_Normal, 0, 27 } /* seqPointIndex: 27 */,
	{ 50701, 2, 30, 30, 9, 51, 8, kSequencePointKind_StepOut, 0, 28 } /* seqPointIndex: 28 */,
	{ 50701, 2, 30, 30, 9, 51, 13, kSequencePointKind_StepOut, 0, 29 } /* seqPointIndex: 29 */,
	{ 50701, 2, 31, 31, 9, 51, 28, kSequencePointKind_Normal, 0, 30 } /* seqPointIndex: 30 */,
	{ 50701, 2, 31, 31, 9, 51, 30, kSequencePointKind_StepOut, 0, 31 } /* seqPointIndex: 31 */,
	{ 50701, 2, 32, 32, 9, 34, 40, kSequencePointKind_Normal, 0, 32 } /* seqPointIndex: 32 */,
	{ 50701, 2, 32, 32, 9, 34, 47, kSequencePointKind_StepOut, 0, 33 } /* seqPointIndex: 33 */,
	{ 50701, 2, 33, 33, 9, 34, 53, kSequencePointKind_Normal, 0, 34 } /* seqPointIndex: 34 */,
	{ 50701, 2, 33, 33, 9, 34, 60, kSequencePointKind_StepOut, 0, 35 } /* seqPointIndex: 35 */,
	{ 50701, 2, 34, 34, 9, 39, 66, kSequencePointKind_Normal, 0, 36 } /* seqPointIndex: 36 */,
	{ 50701, 2, 34, 34, 9, 39, 75, kSequencePointKind_StepOut, 0, 37 } /* seqPointIndex: 37 */,
	{ 50701, 2, 35, 35, 9, 87, 81, kSequencePointKind_Normal, 0, 38 } /* seqPointIndex: 38 */,
	{ 50701, 2, 35, 35, 9, 87, 88, kSequencePointKind_StepOut, 0, 39 } /* seqPointIndex: 39 */,
	{ 50701, 2, 35, 35, 9, 87, 93, kSequencePointKind_StepOut, 0, 40 } /* seqPointIndex: 40 */,
	{ 50701, 2, 35, 35, 9, 87, 101, kSequencePointKind_StepOut, 0, 41 } /* seqPointIndex: 41 */,
	{ 50701, 2, 36, 36, 5, 6, 116, kSequencePointKind_Normal, 0, 42 } /* seqPointIndex: 42 */,
	{ 50702, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 43 } /* seqPointIndex: 43 */,
	{ 50702, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 44 } /* seqPointIndex: 44 */,
	{ 50702, 2, 39, 39, 5, 6, 0, kSequencePointKind_Normal, 0, 45 } /* seqPointIndex: 45 */,
	{ 50702, 2, 40, 40, 9, 48, 1, kSequencePointKind_Normal, 0, 46 } /* seqPointIndex: 46 */,
	{ 50702, 2, 40, 40, 0, 0, 22, kSequencePointKind_Normal, 0, 47 } /* seqPointIndex: 47 */,
	{ 50702, 2, 41, 41, 9, 10, 28, kSequencePointKind_Normal, 0, 48 } /* seqPointIndex: 48 */,
	{ 50702, 2, 42, 42, 13, 44, 29, kSequencePointKind_Normal, 0, 49 } /* seqPointIndex: 49 */,
	{ 50702, 2, 42, 42, 13, 44, 35, kSequencePointKind_StepOut, 0, 50 } /* seqPointIndex: 50 */,
	{ 50702, 2, 42, 42, 0, 0, 45, kSequencePointKind_Normal, 0, 51 } /* seqPointIndex: 51 */,
	{ 50702, 2, 43, 43, 13, 14, 51, kSequencePointKind_Normal, 0, 52 } /* seqPointIndex: 52 */,
	{ 50702, 2, 44, 44, 17, 91, 52, kSequencePointKind_Normal, 0, 53 } /* seqPointIndex: 53 */,
	{ 50702, 2, 44, 44, 17, 91, 58, kSequencePointKind_StepOut, 0, 54 } /* seqPointIndex: 54 */,
	{ 50702, 2, 44, 44, 17, 91, 70, kSequencePointKind_StepOut, 0, 55 } /* seqPointIndex: 55 */,
	{ 50702, 2, 45, 45, 17, 132, 79, kSequencePointKind_Normal, 0, 56 } /* seqPointIndex: 56 */,
	{ 50702, 2, 45, 45, 17, 132, 85, kSequencePointKind_StepOut, 0, 57 } /* seqPointIndex: 57 */,
	{ 50702, 2, 45, 45, 17, 132, 104, kSequencePointKind_StepOut, 0, 58 } /* seqPointIndex: 58 */,
	{ 50702, 2, 45, 45, 17, 132, 109, kSequencePointKind_StepOut, 0, 59 } /* seqPointIndex: 59 */,
	{ 50702, 2, 45, 45, 17, 132, 124, kSequencePointKind_StepOut, 0, 60 } /* seqPointIndex: 60 */,
	{ 50702, 2, 45, 45, 17, 132, 129, kSequencePointKind_StepOut, 0, 61 } /* seqPointIndex: 61 */,
	{ 50702, 2, 46, 46, 17, 163, 135, kSequencePointKind_Normal, 0, 62 } /* seqPointIndex: 62 */,
	{ 50702, 2, 46, 46, 17, 163, 141, kSequencePointKind_StepOut, 0, 63 } /* seqPointIndex: 63 */,
	{ 50702, 2, 46, 46, 17, 163, 152, kSequencePointKind_StepOut, 0, 64 } /* seqPointIndex: 64 */,
	{ 50702, 2, 46, 46, 17, 163, 157, kSequencePointKind_StepOut, 0, 65 } /* seqPointIndex: 65 */,
	{ 50702, 2, 46, 46, 17, 163, 182, kSequencePointKind_StepOut, 0, 66 } /* seqPointIndex: 66 */,
	{ 50702, 2, 46, 46, 17, 163, 187, kSequencePointKind_StepOut, 0, 67 } /* seqPointIndex: 67 */,
	{ 50702, 2, 46, 46, 17, 163, 197, kSequencePointKind_StepOut, 0, 68 } /* seqPointIndex: 68 */,
	{ 50702, 2, 46, 46, 17, 163, 202, kSequencePointKind_StepOut, 0, 69 } /* seqPointIndex: 69 */,
	{ 50702, 2, 46, 46, 17, 163, 207, kSequencePointKind_StepOut, 0, 70 } /* seqPointIndex: 70 */,
	{ 50702, 2, 47, 47, 13, 14, 213, kSequencePointKind_Normal, 0, 71 } /* seqPointIndex: 71 */,
	{ 50702, 2, 48, 48, 9, 10, 214, kSequencePointKind_Normal, 0, 72 } /* seqPointIndex: 72 */,
	{ 50702, 2, 50, 50, 9, 41, 215, kSequencePointKind_Normal, 0, 73 } /* seqPointIndex: 73 */,
	{ 50702, 2, 50, 50, 9, 41, 216, kSequencePointKind_StepOut, 0, 74 } /* seqPointIndex: 74 */,
	{ 50702, 2, 50, 50, 0, 0, 222, kSequencePointKind_Normal, 0, 75 } /* seqPointIndex: 75 */,
	{ 50702, 2, 51, 51, 9, 10, 228, kSequencePointKind_Normal, 0, 76 } /* seqPointIndex: 76 */,
	{ 50702, 2, 52, 52, 13, 47, 229, kSequencePointKind_Normal, 0, 77 } /* seqPointIndex: 77 */,
	{ 50702, 2, 52, 52, 13, 47, 229, kSequencePointKind_StepOut, 0, 78 } /* seqPointIndex: 78 */,
	{ 50702, 2, 53, 53, 13, 98, 236, kSequencePointKind_Normal, 0, 79 } /* seqPointIndex: 79 */,
	{ 50702, 2, 53, 53, 13, 98, 236, kSequencePointKind_StepOut, 0, 80 } /* seqPointIndex: 80 */,
	{ 50702, 2, 53, 53, 13, 98, 243, kSequencePointKind_StepOut, 0, 81 } /* seqPointIndex: 81 */,
	{ 50702, 2, 53, 53, 13, 98, 248, kSequencePointKind_StepOut, 0, 82 } /* seqPointIndex: 82 */,
	{ 50702, 2, 53, 53, 13, 98, 253, kSequencePointKind_StepOut, 0, 83 } /* seqPointIndex: 83 */,
	{ 50702, 2, 55, 55, 13, 77, 260, kSequencePointKind_Normal, 0, 84 } /* seqPointIndex: 84 */,
	{ 50702, 2, 55, 55, 13, 77, 263, kSequencePointKind_StepOut, 0, 85 } /* seqPointIndex: 85 */,
	{ 50702, 2, 55, 55, 13, 77, 278, kSequencePointKind_StepOut, 0, 86 } /* seqPointIndex: 86 */,
	{ 50702, 2, 55, 55, 13, 77, 283, kSequencePointKind_StepOut, 0, 87 } /* seqPointIndex: 87 */,
	{ 50702, 2, 55, 55, 0, 0, 293, kSequencePointKind_Normal, 0, 88 } /* seqPointIndex: 88 */,
	{ 50702, 2, 56, 56, 13, 14, 297, kSequencePointKind_Normal, 0, 89 } /* seqPointIndex: 89 */,
	{ 50702, 2, 57, 57, 17, 32, 298, kSequencePointKind_Normal, 0, 90 } /* seqPointIndex: 90 */,
	{ 50702, 2, 57, 57, 17, 32, 299, kSequencePointKind_StepOut, 0, 91 } /* seqPointIndex: 91 */,
	{ 50702, 2, 58, 58, 13, 14, 305, kSequencePointKind_Normal, 0, 92 } /* seqPointIndex: 92 */,
	{ 50702, 2, 59, 59, 13, 76, 306, kSequencePointKind_Normal, 0, 93 } /* seqPointIndex: 93 */,
	{ 50702, 2, 59, 59, 13, 76, 309, kSequencePointKind_StepOut, 0, 94 } /* seqPointIndex: 94 */,
	{ 50702, 2, 59, 59, 13, 76, 324, kSequencePointKind_StepOut, 0, 95 } /* seqPointIndex: 95 */,
	{ 50702, 2, 59, 59, 13, 76, 329, kSequencePointKind_StepOut, 0, 96 } /* seqPointIndex: 96 */,
	{ 50702, 2, 59, 59, 0, 0, 339, kSequencePointKind_Normal, 0, 97 } /* seqPointIndex: 97 */,
	{ 50702, 2, 60, 60, 13, 14, 343, kSequencePointKind_Normal, 0, 98 } /* seqPointIndex: 98 */,
	{ 50702, 2, 61, 61, 17, 34, 344, kSequencePointKind_Normal, 0, 99 } /* seqPointIndex: 99 */,
	{ 50702, 2, 61, 61, 17, 34, 349, kSequencePointKind_StepOut, 0, 100 } /* seqPointIndex: 100 */,
	{ 50702, 2, 62, 62, 17, 32, 355, kSequencePointKind_Normal, 0, 101 } /* seqPointIndex: 101 */,
	{ 50702, 2, 62, 62, 17, 32, 356, kSequencePointKind_StepOut, 0, 102 } /* seqPointIndex: 102 */,
	{ 50702, 2, 63, 63, 13, 14, 362, kSequencePointKind_Normal, 0, 103 } /* seqPointIndex: 103 */,
	{ 50702, 2, 64, 64, 9, 10, 363, kSequencePointKind_Normal, 0, 104 } /* seqPointIndex: 104 */,
	{ 50702, 2, 65, 65, 5, 6, 364, kSequencePointKind_Normal, 0, 105 } /* seqPointIndex: 105 */,
	{ 50703, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 106 } /* seqPointIndex: 106 */,
	{ 50703, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 107 } /* seqPointIndex: 107 */,
	{ 50703, 2, 68, 68, 5, 6, 0, kSequencePointKind_Normal, 0, 108 } /* seqPointIndex: 108 */,
	{ 50703, 2, 69, 69, 9, 21, 1, kSequencePointKind_Normal, 0, 109 } /* seqPointIndex: 109 */,
	{ 50703, 2, 69, 69, 9, 21, 2, kSequencePointKind_StepOut, 0, 110 } /* seqPointIndex: 110 */,
	{ 50703, 2, 70, 70, 9, 58, 8, kSequencePointKind_Normal, 0, 111 } /* seqPointIndex: 111 */,
	{ 50703, 2, 70, 70, 9, 58, 15, kSequencePointKind_StepOut, 0, 112 } /* seqPointIndex: 112 */,
	{ 50703, 2, 70, 70, 9, 58, 20, kSequencePointKind_StepOut, 0, 113 } /* seqPointIndex: 113 */,
	{ 50703, 2, 71, 71, 9, 48, 35, kSequencePointKind_Normal, 0, 114 } /* seqPointIndex: 114 */,
	{ 50703, 2, 72, 72, 5, 6, 54, kSequencePointKind_Normal, 0, 115 } /* seqPointIndex: 115 */,
	{ 50704, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 116 } /* seqPointIndex: 116 */,
	{ 50704, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 117 } /* seqPointIndex: 117 */,
	{ 50704, 2, 75, 75, 5, 6, 0, kSequencePointKind_Normal, 0, 118 } /* seqPointIndex: 118 */,
	{ 50704, 2, 76, 76, 9, 32, 1, kSequencePointKind_Normal, 0, 119 } /* seqPointIndex: 119 */,
	{ 50704, 2, 77, 77, 9, 31, 8, kSequencePointKind_Normal, 0, 120 } /* seqPointIndex: 120 */,
	{ 50704, 2, 77, 77, 9, 31, 9, kSequencePointKind_StepOut, 0, 121 } /* seqPointIndex: 121 */,
	{ 50704, 2, 78, 78, 9, 21, 15, kSequencePointKind_Normal, 0, 122 } /* seqPointIndex: 122 */,
	{ 50704, 2, 78, 78, 9, 21, 16, kSequencePointKind_StepOut, 0, 123 } /* seqPointIndex: 123 */,
	{ 50704, 2, 79, 79, 9, 21, 22, kSequencePointKind_Normal, 0, 124 } /* seqPointIndex: 124 */,
	{ 50704, 2, 79, 79, 9, 21, 23, kSequencePointKind_StepOut, 0, 125 } /* seqPointIndex: 125 */,
	{ 50704, 2, 80, 80, 9, 59, 29, kSequencePointKind_Normal, 0, 126 } /* seqPointIndex: 126 */,
	{ 50704, 2, 80, 80, 9, 59, 31, kSequencePointKind_StepOut, 0, 127 } /* seqPointIndex: 127 */,
	{ 50704, 2, 80, 80, 9, 59, 36, kSequencePointKind_StepOut, 0, 128 } /* seqPointIndex: 128 */,
	{ 50704, 2, 81, 81, 5, 6, 42, kSequencePointKind_Normal, 0, 129 } /* seqPointIndex: 129 */,
	{ 50706, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 130 } /* seqPointIndex: 130 */,
	{ 50706, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 131 } /* seqPointIndex: 131 */,
	{ 50706, 2, 90, 90, 5, 6, 0, kSequencePointKind_Normal, 0, 132 } /* seqPointIndex: 132 */,
	{ 50706, 2, 91, 91, 9, 31, 1, kSequencePointKind_Normal, 0, 133 } /* seqPointIndex: 133 */,
	{ 50706, 2, 92, 92, 9, 31, 8, kSequencePointKind_Normal, 0, 134 } /* seqPointIndex: 134 */,
	{ 50706, 2, 93, 93, 9, 92, 15, kSequencePointKind_Normal, 0, 135 } /* seqPointIndex: 135 */,
	{ 50706, 2, 93, 93, 9, 92, 15, kSequencePointKind_StepOut, 0, 136 } /* seqPointIndex: 136 */,
	{ 50706, 2, 93, 93, 9, 92, 25, kSequencePointKind_StepOut, 0, 137 } /* seqPointIndex: 137 */,
	{ 50706, 2, 93, 93, 9, 92, 35, kSequencePointKind_StepOut, 0, 138 } /* seqPointIndex: 138 */,
	{ 50706, 2, 93, 93, 9, 92, 40, kSequencePointKind_StepOut, 0, 139 } /* seqPointIndex: 139 */,
	{ 50706, 2, 94, 94, 9, 78, 46, kSequencePointKind_Normal, 0, 140 } /* seqPointIndex: 140 */,
	{ 50706, 2, 94, 94, 9, 78, 46, kSequencePointKind_StepOut, 0, 141 } /* seqPointIndex: 141 */,
	{ 50706, 2, 94, 94, 9, 78, 52, kSequencePointKind_StepOut, 0, 142 } /* seqPointIndex: 142 */,
	{ 50706, 2, 95, 95, 9, 77, 58, kSequencePointKind_Normal, 0, 143 } /* seqPointIndex: 143 */,
	{ 50706, 2, 95, 95, 9, 77, 64, kSequencePointKind_StepOut, 0, 144 } /* seqPointIndex: 144 */,
	{ 50706, 2, 95, 95, 9, 77, 81, kSequencePointKind_StepOut, 0, 145 } /* seqPointIndex: 145 */,
	{ 50706, 2, 95, 95, 9, 77, 86, kSequencePointKind_StepOut, 0, 146 } /* seqPointIndex: 146 */,
	{ 50706, 2, 95, 95, 9, 77, 91, kSequencePointKind_StepOut, 0, 147 } /* seqPointIndex: 147 */,
	{ 50706, 2, 96, 96, 9, 51, 97, kSequencePointKind_Normal, 0, 148 } /* seqPointIndex: 148 */,
	{ 50706, 2, 96, 96, 9, 51, 104, kSequencePointKind_StepOut, 0, 149 } /* seqPointIndex: 149 */,
	{ 50706, 2, 96, 96, 9, 51, 109, kSequencePointKind_StepOut, 0, 150 } /* seqPointIndex: 150 */,
	{ 50706, 2, 97, 97, 9, 33, 124, kSequencePointKind_Normal, 0, 151 } /* seqPointIndex: 151 */,
	{ 50706, 2, 97, 97, 0, 0, 139, kSequencePointKind_Normal, 0, 152 } /* seqPointIndex: 152 */,
	{ 50706, 2, 97, 97, 34, 35, 142, kSequencePointKind_Normal, 0, 153 } /* seqPointIndex: 153 */,
	{ 50706, 2, 97, 97, 36, 56, 143, kSequencePointKind_Normal, 0, 154 } /* seqPointIndex: 154 */,
	{ 50706, 2, 97, 97, 57, 58, 155, kSequencePointKind_Normal, 0, 155 } /* seqPointIndex: 155 */,
	{ 50706, 2, 98, 98, 9, 33, 156, kSequencePointKind_Normal, 0, 156 } /* seqPointIndex: 156 */,
	{ 50706, 2, 98, 98, 0, 0, 171, kSequencePointKind_Normal, 0, 157 } /* seqPointIndex: 157 */,
	{ 50706, 2, 98, 98, 34, 35, 174, kSequencePointKind_Normal, 0, 158 } /* seqPointIndex: 158 */,
	{ 50706, 2, 98, 98, 36, 56, 175, kSequencePointKind_Normal, 0, 159 } /* seqPointIndex: 159 */,
	{ 50706, 2, 98, 98, 57, 58, 187, kSequencePointKind_Normal, 0, 160 } /* seqPointIndex: 160 */,
	{ 50706, 2, 99, 99, 9, 72, 188, kSequencePointKind_Normal, 0, 161 } /* seqPointIndex: 161 */,
	{ 50706, 2, 99, 99, 9, 72, 194, kSequencePointKind_StepOut, 0, 162 } /* seqPointIndex: 162 */,
	{ 50706, 2, 99, 99, 9, 72, 211, kSequencePointKind_StepOut, 0, 163 } /* seqPointIndex: 163 */,
	{ 50706, 2, 99, 99, 9, 72, 216, kSequencePointKind_StepOut, 0, 164 } /* seqPointIndex: 164 */,
	{ 50706, 2, 99, 99, 9, 72, 221, kSequencePointKind_StepOut, 0, 165 } /* seqPointIndex: 165 */,
	{ 50706, 2, 100, 100, 9, 31, 227, kSequencePointKind_Normal, 0, 166 } /* seqPointIndex: 166 */,
	{ 50706, 2, 100, 100, 9, 31, 228, kSequencePointKind_StepOut, 0, 167 } /* seqPointIndex: 167 */,
	{ 50706, 2, 101, 101, 9, 131, 234, kSequencePointKind_Normal, 0, 168 } /* seqPointIndex: 168 */,
	{ 50706, 2, 101, 101, 9, 131, 240, kSequencePointKind_StepOut, 0, 169 } /* seqPointIndex: 169 */,
	{ 50706, 2, 101, 101, 9, 131, 264, kSequencePointKind_StepOut, 0, 170 } /* seqPointIndex: 170 */,
	{ 50706, 2, 101, 101, 9, 131, 269, kSequencePointKind_StepOut, 0, 171 } /* seqPointIndex: 171 */,
	{ 50706, 2, 101, 101, 9, 131, 284, kSequencePointKind_StepOut, 0, 172 } /* seqPointIndex: 172 */,
	{ 50706, 2, 101, 101, 9, 131, 289, kSequencePointKind_StepOut, 0, 173 } /* seqPointIndex: 173 */,
	{ 50706, 2, 102, 102, 5, 6, 295, kSequencePointKind_Normal, 0, 174 } /* seqPointIndex: 174 */,
	{ 50707, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 175 } /* seqPointIndex: 175 */,
	{ 50707, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 176 } /* seqPointIndex: 176 */,
	{ 50707, 2, 105, 105, 5, 6, 0, kSequencePointKind_Normal, 0, 177 } /* seqPointIndex: 177 */,
	{ 50707, 2, 106, 106, 9, 32, 1, kSequencePointKind_Normal, 0, 178 } /* seqPointIndex: 178 */,
	{ 50707, 2, 107, 107, 5, 6, 8, kSequencePointKind_Normal, 0, 179 } /* seqPointIndex: 179 */,
	{ 50708, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 180 } /* seqPointIndex: 180 */,
	{ 50708, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 181 } /* seqPointIndex: 181 */,
	{ 50708, 2, 110, 110, 5, 6, 0, kSequencePointKind_Normal, 0, 182 } /* seqPointIndex: 182 */,
	{ 50708, 2, 111, 111, 9, 44, 1, kSequencePointKind_Normal, 0, 183 } /* seqPointIndex: 183 */,
	{ 50708, 2, 112, 112, 9, 63, 20, kSequencePointKind_Normal, 0, 184 } /* seqPointIndex: 184 */,
	{ 50708, 2, 112, 112, 9, 63, 27, kSequencePointKind_StepOut, 0, 185 } /* seqPointIndex: 185 */,
	{ 50708, 2, 112, 112, 9, 63, 32, kSequencePointKind_StepOut, 0, 186 } /* seqPointIndex: 186 */,
	{ 50708, 2, 113, 113, 9, 52, 54, kSequencePointKind_Normal, 0, 187 } /* seqPointIndex: 187 */,
	{ 50708, 2, 114, 114, 5, 6, 73, kSequencePointKind_Normal, 0, 188 } /* seqPointIndex: 188 */,
	{ 50709, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 189 } /* seqPointIndex: 189 */,
	{ 50709, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 190 } /* seqPointIndex: 190 */,
	{ 50709, 2, 117, 117, 5, 6, 0, kSequencePointKind_Normal, 0, 191 } /* seqPointIndex: 191 */,
	{ 50709, 2, 118, 118, 9, 62, 1, kSequencePointKind_Normal, 0, 192 } /* seqPointIndex: 192 */,
	{ 50709, 2, 118, 118, 9, 62, 7, kSequencePointKind_StepOut, 0, 193 } /* seqPointIndex: 193 */,
	{ 50709, 2, 119, 119, 9, 41, 22, kSequencePointKind_Normal, 0, 194 } /* seqPointIndex: 194 */,
	{ 50709, 2, 119, 119, 9, 41, 30, kSequencePointKind_StepOut, 0, 195 } /* seqPointIndex: 195 */,
	{ 50709, 2, 120, 120, 5, 6, 36, kSequencePointKind_Normal, 0, 196 } /* seqPointIndex: 196 */,
	{ 50710, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 197 } /* seqPointIndex: 197 */,
	{ 50710, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 198 } /* seqPointIndex: 198 */,
	{ 50710, 2, 123, 123, 5, 6, 0, kSequencePointKind_Normal, 0, 199 } /* seqPointIndex: 199 */,
	{ 50710, 2, 124, 124, 9, 28, 1, kSequencePointKind_Normal, 0, 200 } /* seqPointIndex: 200 */,
	{ 50710, 2, 124, 124, 0, 0, 8, kSequencePointKind_Normal, 0, 201 } /* seqPointIndex: 201 */,
	{ 50710, 2, 125, 125, 9, 10, 11, kSequencePointKind_Normal, 0, 202 } /* seqPointIndex: 202 */,
	{ 50710, 2, 126, 126, 13, 25, 12, kSequencePointKind_Normal, 0, 203 } /* seqPointIndex: 203 */,
	{ 50710, 2, 126, 126, 13, 25, 13, kSequencePointKind_StepOut, 0, 204 } /* seqPointIndex: 204 */,
	{ 50710, 2, 127, 127, 9, 10, 19, kSequencePointKind_Normal, 0, 205 } /* seqPointIndex: 205 */,
	{ 50710, 2, 127, 127, 0, 0, 20, kSequencePointKind_Normal, 0, 206 } /* seqPointIndex: 206 */,
	{ 50710, 2, 129, 129, 9, 10, 22, kSequencePointKind_Normal, 0, 207 } /* seqPointIndex: 207 */,
	{ 50710, 2, 130, 130, 13, 25, 23, kSequencePointKind_Normal, 0, 208 } /* seqPointIndex: 208 */,
	{ 50710, 2, 130, 130, 13, 25, 24, kSequencePointKind_StepOut, 0, 209 } /* seqPointIndex: 209 */,
	{ 50710, 2, 131, 131, 9, 10, 30, kSequencePointKind_Normal, 0, 210 } /* seqPointIndex: 210 */,
	{ 50710, 2, 132, 132, 5, 6, 31, kSequencePointKind_Normal, 0, 211 } /* seqPointIndex: 211 */,
	{ 50711, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 212 } /* seqPointIndex: 212 */,
	{ 50711, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 213 } /* seqPointIndex: 213 */,
	{ 50711, 2, 135, 135, 5, 6, 0, kSequencePointKind_Normal, 0, 214 } /* seqPointIndex: 214 */,
	{ 50711, 2, 136, 136, 9, 32, 1, kSequencePointKind_Normal, 0, 215 } /* seqPointIndex: 215 */,
	{ 50711, 2, 137, 137, 9, 29, 8, kSequencePointKind_Normal, 0, 216 } /* seqPointIndex: 216 */,
	{ 50711, 2, 137, 137, 9, 29, 14, kSequencePointKind_StepOut, 0, 217 } /* seqPointIndex: 217 */,
	{ 50711, 2, 138, 138, 9, 35, 20, kSequencePointKind_Normal, 0, 218 } /* seqPointIndex: 218 */,
	{ 50711, 2, 138, 138, 9, 35, 27, kSequencePointKind_StepOut, 0, 219 } /* seqPointIndex: 219 */,
	{ 50711, 2, 139, 139, 9, 33, 33, kSequencePointKind_Normal, 0, 220 } /* seqPointIndex: 220 */,
	{ 50711, 2, 139, 139, 9, 33, 40, kSequencePointKind_StepOut, 0, 221 } /* seqPointIndex: 221 */,
	{ 50711, 2, 140, 140, 5, 6, 46, kSequencePointKind_Normal, 0, 222 } /* seqPointIndex: 222 */,
	{ 50712, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 223 } /* seqPointIndex: 223 */,
	{ 50712, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 224 } /* seqPointIndex: 224 */,
	{ 50712, 2, 143, 143, 5, 6, 0, kSequencePointKind_Normal, 0, 225 } /* seqPointIndex: 225 */,
	{ 50712, 2, 144, 144, 9, 31, 1, kSequencePointKind_Normal, 0, 226 } /* seqPointIndex: 226 */,
	{ 50712, 2, 145, 145, 9, 28, 8, kSequencePointKind_Normal, 0, 227 } /* seqPointIndex: 227 */,
	{ 50712, 2, 145, 145, 9, 28, 14, kSequencePointKind_StepOut, 0, 228 } /* seqPointIndex: 228 */,
	{ 50712, 2, 146, 146, 9, 34, 20, kSequencePointKind_Normal, 0, 229 } /* seqPointIndex: 229 */,
	{ 50712, 2, 146, 146, 9, 34, 27, kSequencePointKind_StepOut, 0, 230 } /* seqPointIndex: 230 */,
	{ 50712, 2, 147, 147, 9, 34, 33, kSequencePointKind_Normal, 0, 231 } /* seqPointIndex: 231 */,
	{ 50712, 2, 147, 147, 9, 34, 40, kSequencePointKind_StepOut, 0, 232 } /* seqPointIndex: 232 */,
	{ 50712, 2, 148, 148, 5, 6, 46, kSequencePointKind_Normal, 0, 233 } /* seqPointIndex: 233 */,
	{ 50713, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 234 } /* seqPointIndex: 234 */,
	{ 50713, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 235 } /* seqPointIndex: 235 */,
	{ 50713, 2, 24, 24, 5, 41, 0, kSequencePointKind_Normal, 0, 236 } /* seqPointIndex: 236 */,
	{ 50713, 2, 25, 25, 5, 41, 7, kSequencePointKind_Normal, 0, 237 } /* seqPointIndex: 237 */,
	{ 50713, 2, 25, 25, 5, 41, 15, kSequencePointKind_StepOut, 0, 238 } /* seqPointIndex: 238 */,
	{ 50716, 0, 0, 0, 0, 0, -1, kSequencePointKind_Normal, 0, 239 } /* seqPointIndex: 239 */,
	{ 50716, 0, 0, 0, 0, 0, 16777215, kSequencePointKind_Normal, 0, 240 } /* seqPointIndex: 240 */,
	{ 50716, 2, 0, 0, 0, 0, 0, kSequencePointKind_Normal, 0, 241 } /* seqPointIndex: 241 */,
	{ 50716, 2, 84, 84, 5, 6, 31, kSequencePointKind_Normal, 0, 242 } /* seqPointIndex: 242 */,
	{ 50716, 2, 85, 85, 9, 44, 32, kSequencePointKind_Normal, 0, 243 } /* seqPointIndex: 243 */,
	{ 50716, 2, 85, 85, 9, 44, 38, kSequencePointKind_StepOut, 0, 244 } /* seqPointIndex: 244 */,
	{ 50716, 2, 85, 85, 0, 0, 57, kSequencePointKind_Normal, 0, 245 } /* seqPointIndex: 245 */,
	{ 50716, 2, 86, 86, 9, 36, 64, kSequencePointKind_Normal, 0, 246 } /* seqPointIndex: 246 */,
	{ 50716, 2, 86, 86, 9, 36, 70, kSequencePointKind_StepOut, 0, 247 } /* seqPointIndex: 247 */,
	{ 50716, 2, 87, 87, 5, 6, 76, kSequencePointKind_Normal, 0, 248 } /* seqPointIndex: 248 */,
};
#else
extern Il2CppSequencePoint g_sequencePointsPlugin[];
Il2CppSequencePoint g_sequencePointsPlugin[1] = { { 0, 0, 0, 0, 0, 0, 0, kSequencePointKind_Normal, 0, 0, } };
#endif
#if IL2CPP_MONO_DEBUGGER
static const Il2CppCatchPoint g_catchPoints[1] = { { 0, 0, 0, 0, } };
#else
static const Il2CppCatchPoint g_catchPoints[1] = { { 0, 0, 0, 0, } };
#endif
#if IL2CPP_MONO_DEBUGGER
static const Il2CppSequencePointSourceFile g_sequencePointSourceFiles[] = {
{ "", { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} }, //0 
{ "D:\\Desenvolvimento\\Unity\\VT8\\SimuladorVT8\\Assets\\Plug-in\\_VideoPlayer\\Scripts\\Knob.cs", { 182, 187, 74, 178, 107, 169, 66, 17, 8, 210, 173, 62, 58, 173, 60, 82} }, //1 
{ "D:\\Desenvolvimento\\Unity\\VT8\\SimuladorVT8\\Assets\\Plug-in\\_VideoPlayer\\Scripts\\MyVideoPlayer.cs", { 175, 170, 170, 227, 5, 80, 183, 152, 200, 172, 194, 55, 235, 217, 211, 51} }, //2 
};
#else
static const Il2CppSequencePointSourceFile g_sequencePointSourceFiles[1] = { NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
#endif
#if IL2CPP_MONO_DEBUGGER
static const Il2CppTypeSourceFilePair g_typeSourceFiles[3] = 
{
	{ 7182, 1 },
	{ 7184, 2 },
	{ 7183, 2 },
};
#else
static const Il2CppTypeSourceFilePair g_typeSourceFiles[1] = { { 0, 0 } };
#endif
#if IL2CPP_MONO_DEBUGGER
static const Il2CppMethodScope g_methodScopes[8] = 
{
	{ 0, 117 },
	{ 0, 365 },
	{ 51, 214 },
	{ 228, 364 },
	{ 0, 296 },
	{ 0, 37 },
	{ 0, 32 },
	{ 0, 78 },
};
#else
static const Il2CppMethodScope g_methodScopes[1] = { { 0, 0 } };
#endif
#if IL2CPP_MONO_DEBUGGER
static const Il2CppMethodHeaderInfo g_methodHeaderInfos[24] = 
{
	{ 0, 0, 0 } /* System.Void Knob::Start() */,
	{ 0, 0, 0 } /* System.Void Knob::OnMouseDown() */,
	{ 0, 0, 0 } /* System.Void Knob::OnMouseUp() */,
	{ 0, 0, 0 } /* System.Void Knob::OnMouseDrag() */,
	{ 0, 0, 0 } /* System.Void Knob::.ctor() */,
	{ 117, 0, 1 } /* System.Void MyVideoPlayer::Start() */,
	{ 365, 1, 3 } /* System.Void MyVideoPlayer::Update() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer::KnobOnPressDown() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer::KnobOnRelease() */,
	{ 0, 0, 0 } /* System.Collections.IEnumerator MyVideoPlayer::DelayedSetVideoIsJumpingToFalse() */,
	{ 296, 4, 1 } /* System.Void MyVideoPlayer::KnobOnDrag() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer::SetVideoIsJumpingToFalse() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer::CalcKnobSimpleValue() */,
	{ 37, 5, 1 } /* System.Void MyVideoPlayer::VideoJump() */,
	{ 32, 6, 1 } /* System.Void MyVideoPlayer::BtnPlayVideo() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer::VideoStop() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer::VideoPlay() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer::.ctor() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::.ctor(System.Int32) */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::System.IDisposable.Dispose() */,
	{ 78, 7, 1 } /* System.Boolean MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::MoveNext() */,
	{ 0, 0, 0 } /* System.Object MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::System.Collections.Generic.IEnumerator<System.Object>.get_Current() */,
	{ 0, 0, 0 } /* System.Void MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::System.Collections.IEnumerator.Reset() */,
	{ 0, 0, 0 } /* System.Object MyVideoPlayer/<DelayedSetVideoIsJumpingToFalse>d__22::System.Collections.IEnumerator.get_Current() */,
};
#else
static const Il2CppMethodHeaderInfo g_methodHeaderInfos[1] = { { 0, 0, 0 } };
#endif
IL2CPP_EXTERN_C const Il2CppDebuggerMetadataRegistration g_DebuggerMetadataRegistrationPlugin;
const Il2CppDebuggerMetadataRegistration g_DebuggerMetadataRegistrationPlugin = 
{
	(Il2CppMethodExecutionContextInfo*)g_methodExecutionContextInfos,
	(Il2CppMethodExecutionContextInfoIndex*)g_methodExecutionContextInfoIndexes,
	(Il2CppMethodScope*)g_methodScopes,
	(Il2CppMethodHeaderInfo*)g_methodHeaderInfos,
	(Il2CppSequencePointSourceFile*)g_sequencePointSourceFiles,
	249,
	(Il2CppSequencePoint*)g_sequencePointsPlugin,
	0,
	(Il2CppCatchPoint*)g_catchPoints,
	3,
	(Il2CppTypeSourceFilePair*)g_typeSourceFiles,
	(const char**)g_methodExecutionContextInfoStrings,
};
