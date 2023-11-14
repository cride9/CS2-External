/*
 * Created using https://github.com/a2x/cs2-dumper
 * Wed, 8 Nov 2023 19:27:10 +0000
 */
namespace CSharp {

    public static class client_dll { // client.dll
        public const long dwBaseEntityModel_setModel = 0x583180;
        public const long dwEntityList = 0x17ADAF0;
        public const long dwForceBackward = 0x16B25D0;
        public const long dwForceCrouch = 0x16B28A0;
        public const long dwForceForward = 0x16B2540;
        public const long dwForceJump = 0x16B2810;
        public const long dwForceLeft = 0x16B2660;
        public const long dwForceRight = 0x16B26F0;
        public const long dwGameEntitySystem = 0x18D8110;
        public const long dwGameEntitySystem_getBaseEntity = 0x606790;
        public const long dwGameEntitySystem_getHighestEntityIndex = 0x5F8480;
        public const long dwGameRules = 0x1809740;
        public const long dwGlobalVars = 0x16AE488;
        public const long dwGlowManager = 0x1809768;
        public const long dwInterfaceLinkList = 0x1905DA8;
        public const long dwLocalPlayerController = 0x17FCDC8;
        public const long dwLocalPlayerPawn = 0x16B9380;
        public const long dwPlantedC4 = 0x1810CD8;
        public const long dwPrediction = 0x16B9250;
        public const long dwViewAngles = 0x186B108;
        public const long dwViewMatrix = 0x180C100;
        public const long dwViewRender = 0x180C958;
    }

    public static class engine2_dll { // engine2.dll
        public const long dwBuildNumber = 0x48B524;
        public const long dwNetworkGameClient = 0x48AAC0;
        public const long dwNetworkGameClient_getLocalPlayer = 0xF0;
        public const long dwNetworkGameClient_maxClients = 0x250;
        public const long dwNetworkGameClient_signOnState = 0x240;
        public const long dwWindowHeight = 0x541E1C;
        public const long dwWindowWidth = 0x541E18;
    }

    public static class inputsystem_dll { // inputsystem.dll
        public const long dwInputSystem = 0x35770;
    }

    public static class CBasePlayerController { // C_BaseEntity
        public const long m_nFinalPredictedTick = 0x548; // int32_t
        public const long m_CommandContext = 0x550; // C_CommandContext
        public const long m_nInButtonsWhichAreToggles = 0x5E8; // uint64_t
        public const long m_nTickBase = 0x5F0; // uint32_t
        public const long m_hPawn = 0x5F4; // CHandle<C_BasePlayerPawn>
        public const long m_hPredictedPawn = 0x5F8; // CHandle<C_BasePlayerPawn>
        public const long m_nSplitScreenSlot = 0x5FC; // CSplitScreenSlot
        public const long m_hSplitOwner = 0x600; // CHandle<CBasePlayerController>
        public const long m_hSplitScreenPlayers = 0x608; // CUtlVector<CHandle<CBasePlayerController>>
        public const long m_bIsHLTV = 0x620; // bool
        public const long m_iConnected = 0x624; // PlayerConnectedState
        public const long m_iszPlayerName = 0x628; // char[128]
        public const long m_steamID = 0x6B0; // uint64_t
        public const long m_bIsLocalPlayerController = 0x6B8; // bool
        public const long m_iDesiredFOV = 0x6BC; // uint32_t
    }
    public static class CCSPlayerController { // CBasePlayerController
        public const long m_pInGameMoneyServices = 0x6E8; // CCSPlayerController_InGameMoneyServices*
        public const long m_pInventoryServices = 0x6F0; // CCSPlayerController_InventoryServices*
        public const long m_pActionTrackingServices = 0x6F8; // CCSPlayerController_ActionTrackingServices*
        public const long m_pDamageServices = 0x700; // CCSPlayerController_DamageServices*
        public const long m_iPing = 0x708; // uint32_t
        public const long m_bHasCommunicationAbuseMute = 0x70C; // bool
        public const long m_szCrosshairCodes = 0x710; // CUtlSymbolLarge
        public const long m_iPendingTeamNum = 0x718; // uint8_t
        public const long m_flForceTeamTime = 0x71C; // GameTime_t
        public const long m_iCompTeammateColor = 0x720; // int32_t
        public const long m_bEverPlayedOnTeam = 0x724; // bool
        public const long m_flPreviousForceJoinTeamTime = 0x728; // GameTime_t
        public const long m_szClan = 0x730; // CUtlSymbolLarge
        public const long m_sSanitizedPlayerName = 0x738; // CUtlString
        public const long m_iCoachingTeam = 0x740; // int32_t
        public const long m_nPlayerDominated = 0x748; // uint64_t
        public const long m_nPlayerDominatingMe = 0x750; // uint64_t
        public const long m_iCompetitiveRanking = 0x758; // int32_t
        public const long m_iCompetitiveWins = 0x75C; // int32_t
        public const long m_iCompetitiveRankType = 0x760; // int8_t
        public const long m_iCompetitiveRankingPredicted_Win = 0x764; // int32_t
        public const long m_iCompetitiveRankingPredicted_Loss = 0x768; // int32_t
        public const long m_iCompetitiveRankingPredicted_Tie = 0x76C; // int32_t
        public const long m_nEndMatchNextMapVote = 0x770; // int32_t
        public const long m_unActiveQuestId = 0x774; // uint16_t
        public const long m_nQuestProgressReason = 0x778; // QuestProgress::Reason
        public const long m_unPlayerTvControlFlags = 0x77C; // uint32_t
        public const long m_iDraftIndex = 0x7A8; // int32_t
        public const long m_msQueuedModeDisconnectionTimestamp = 0x7AC; // uint32_t
        public const long m_uiAbandonRecordedReason = 0x7B0; // uint32_t
        public const long m_bCannotBeKicked = 0x7B4; // bool
        public const long m_bEverFullyConnected = 0x7B5; // bool
        public const long m_bAbandonAllowsSurrender = 0x7B6; // bool
        public const long m_bAbandonOffersInstantSurrender = 0x7B7; // bool
        public const long m_bDisconnection1MinWarningPrinted = 0x7B8; // bool
        public const long m_bScoreReported = 0x7B9; // bool
        public const long m_nDisconnectionTick = 0x7BC; // int32_t
        public const long m_bControllingBot = 0x7C8; // bool
        public const long m_bHasControlledBotThisRound = 0x7C9; // bool
        public const long m_bHasBeenControlledByPlayerThisRound = 0x7CA; // bool
        public const long m_nBotsControlledThisRound = 0x7CC; // int32_t
        public const long m_bCanControlObservedBot = 0x7D0; // bool
        public const long m_hPlayerPawn = 0x7D4; // CHandle<C_CSPlayerPawn>
        public const long m_hObserverPawn = 0x7D8; // CHandle<C_CSObserverPawn>
        public const long m_bPawnIsAlive = 0x7DC; // bool
        public const long m_iPawnHealth = 0x7E0; // uint32_t
        public const long m_iPawnArmor = 0x7E4; // int32_t
        public const long m_bPawnHasDefuser = 0x7E8; // bool
        public const long m_bPawnHasHelmet = 0x7E9; // bool
        public const long m_nPawnCharacterDefIndex = 0x7EA; // uint16_t
        public const long m_iPawnLifetimeStart = 0x7EC; // int32_t
        public const long m_iPawnLifetimeEnd = 0x7F0; // int32_t
        public const long m_iPawnBotDifficulty = 0x7F4; // int32_t
        public const long m_hOriginalControllerOfCurrentPawn = 0x7F8; // CHandle<CCSPlayerController>
        public const long m_iScore = 0x7FC; // int32_t
        public const long m_vecKills = 0x800; // C_NetworkUtlVectorBase<EKillTypes_t>
        public const long m_iMVPs = 0x818; // int32_t
        public const long m_bIsPlayerNameDirty = 0x81C; // bool
    }

    public static class C_BaseEntity { // CEntityInstance
        public const long m_CBodyComponent = 0x30; // CBodyComponent*
        public const long m_NetworkTransmitComponent = 0x38; // CNetworkTransmitComponent
        public const long m_nLastThinkTick = 0x308; // GameTick_t
        public const long m_pGameSceneNode = 0x310; // CGameSceneNode*
        public const long m_pRenderComponent = 0x318; // CRenderComponent*
        public const long m_pCollision = 0x320; // CCollisionProperty*
        public const long m_iMaxHealth = 0x328; // int32_t
        public const long m_iHealth = 0x32C; // int32_t
        public const long m_lifeState = 0x330; // uint8_t
        public const long m_bTakesDamage = 0x331; // bool
        public const long m_nTakeDamageFlags = 0x334; // TakeDamageFlags_t
        public const long m_ubInterpolationFrame = 0x338; // uint8_t
        public const long m_hSceneObjectController = 0x33C; // CHandle<C_BaseEntity>
        public const long m_nNoInterpolationTick = 0x340; // int32_t
        public const long m_nVisibilityNoInterpolationTick = 0x344; // int32_t
        public const long m_flProxyRandomValue = 0x348; // float
        public const long m_iEFlags = 0x34C; // int32_t
        public const long m_nWaterType = 0x350; // uint8_t
        public const long m_bInterpolateEvenWithNoModel = 0x351; // bool
        public const long m_bPredictionEligible = 0x352; // bool
        public const long m_bApplyLayerMatchIDToModel = 0x353; // bool
        public const long m_tokLayerMatchID = 0x354; // CUtlStringToken
        public const long m_nSubclassID = 0x358; // CUtlStringToken
        public const long m_nSimulationTick = 0x368; // int32_t
        public const long m_iCurrentThinkContext = 0x36C; // int32_t
        public const long m_aThinkFunctions = 0x370; // CUtlVector<thinkfunc_t>
        public const long m_flAnimTime = 0x388; // float
        public const long m_flSimulationTime = 0x38C; // float
        public const long m_nSceneObjectOverrideFlags = 0x390; // uint8_t
        public const long m_bHasSuccessfullyInterpolated = 0x391; // bool
        public const long m_bHasAddedVarsToInterpolation = 0x392; // bool
        public const long m_bRenderEvenWhenNotSuccessfullyInterpolated = 0x393; // bool
        public const long m_longerpolationLatchDirtyFlags = 0x394; // int32_t[2]
        public const long m_ListEntry = 0x39C; // uint16_t[11]
        public const long m_flCreateTime = 0x3B4; // GameTime_t
        public const long m_flSpeed = 0x3B8; // float
        public const long m_EntClientFlags = 0x3BC; // uint16_t
        public const long m_bClientSideRagdoll = 0x3BE; // bool
        public const long m_iTeamNum = 0x3BF; // uint8_t
        public const long m_spawnflags = 0x3C0; // uint32_t
        public const long m_nNextThinkTick = 0x3C4; // GameTick_t
        public const long m_fFlags = 0x3C8; // uint32_t
        public const long m_vecAbsVelocity = 0x3CC; // Vector
        public const long m_vecVelocity = 0x3D8; // CNetworkVelocityVector
        public const long m_vecBaseVelocity = 0x408; // Vector
        public const long m_hEffectEntity = 0x414; // CHandle<C_BaseEntity>
        public const long m_hOwnerEntity = 0x418; // CHandle<C_BaseEntity>
        public const long m_MoveCollide = 0x41C; // MoveCollide_t
        public const long m_MoveType = 0x41D; // MoveType_t
        public const long m_flWaterLevel = 0x420; // float
        public const long m_fEffects = 0x424; // uint32_t
        public const long m_hGroundEntity = 0x428; // CHandle<C_BaseEntity>
        public const long m_flFriction = 0x42C; // float
        public const long m_flElasticity = 0x430; // float
        public const long m_flGravityScale = 0x434; // float
        public const long m_flTimeScale = 0x438; // float
        public const long m_bSimulatedEveryTick = 0x43C; // bool
        public const long m_bAnimatedEveryTick = 0x43D; // bool
        public const long m_flNavIgnoreUntilTime = 0x440; // GameTime_t
        public const long m_hThink = 0x444; // uint16_t
        public const long m_fBBoxVisFlags = 0x450; // uint8_t
        public const long m_bPredictable = 0x451; // bool
        public const long m_bRenderWithViewModels = 0x452; // bool
        public const long m_nSplitUserPlayerPredictionSlot = 0x454; // CSplitScreenSlot
        public const long m_nFirstPredictableCommand = 0x458; // int32_t
        public const long m_nLastPredictableCommand = 0x45C; // int32_t
        public const long m_hOldMoveParent = 0x460; // CHandle<C_BaseEntity>
        public const long m_Particles = 0x468; // CParticleProperty
        public const long m_vecPredictedScriptFloats = 0x490; // CUtlVector<float>
        public const long m_vecPredictedScriptFloatIDs = 0x4A8; // CUtlVector<int32_t>
        public const long m_nNextScriptVarRecordID = 0x4D8; // int32_t
        public const long m_vecAngVelocity = 0x4E8; // QAngle
        public const long m_DataChangeEventRef = 0x4F4; // int32_t
        public const long m_dependencies = 0x4F8; // CUtlVector<CEntityHandle>
        public const long m_nCreationTick = 0x510; // int32_t
        public const long m_bAnimTimeChanged = 0x529; // bool
        public const long m_bSimulationTimeChanged = 0x52A; // bool
        public const long m_sUniqueHammerID = 0x538; // CUtlString
    }
}