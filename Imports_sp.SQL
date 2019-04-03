SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140SelectByID]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140SelectByID]
  @LoginID NVarChar(8),
  @t_cprj VarChar(9),
  @t_docn VarChar(32) 
  AS
  SELECT
    [tdmisg140200].*  
  FROM [tdmisg140200] 
  WHERE
  [tdmisg140200].[t_cprj] = @t_cprj
  AND [tdmisg140200].[t_docn] = @t_docn
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140SelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_docn VarChar(32) NOT NULL
  )
  INSERT INTO #PageIndex (t_cprj, t_docn)
  SELECT [tdmisg140200].[t_cprj], [tdmisg140200].[t_docn] FROM [tdmisg140200]
 WHERE  
   ( 
         LOWER(ISNULL([tdmisg140200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_docn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_revn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_dsca],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_cspa],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg140200].[t_resp],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_cprj' THEN [tdmisg140200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [tdmisg140200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_docn' THEN [tdmisg140200].[t_docn] END,
     CASE @OrderBy WHEN 't_docn DESC' THEN [tdmisg140200].[t_docn] END DESC,
     CASE @OrderBy WHEN 't_revn' THEN [tdmisg140200].[t_revn] END,
     CASE @OrderBy WHEN 't_revn DESC' THEN [tdmisg140200].[t_revn] END DESC,
     CASE @OrderBy WHEN 't_dsca' THEN [tdmisg140200].[t_dsca] END,
     CASE @OrderBy WHEN 't_dsca DESC' THEN [tdmisg140200].[t_dsca] END DESC,
     CASE @OrderBy WHEN 't_cspa' THEN [tdmisg140200].[t_cspa] END,
     CASE @OrderBy WHEN 't_cspa DESC' THEN [tdmisg140200].[t_cspa] END DESC,
     CASE @OrderBy WHEN 't_resp' THEN [tdmisg140200].[t_resp] END,
     CASE @OrderBy WHEN 't_resp DESC' THEN [tdmisg140200].[t_resp] END DESC,
     CASE @OrderBy WHEN 't_lrrd' THEN [tdmisg140200].[t_lrrd] END,
     CASE @OrderBy WHEN 't_lrrd DESC' THEN [tdmisg140200].[t_lrrd] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [tdmisg140200].*  
  FROM [tdmisg140200] 
      INNER JOIN #PageIndex
          ON [tdmisg140200].[t_cprj] = #PageIndex.t_cprj
          AND [tdmisg140200].[t_docn] = #PageIndex.t_docn
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg140SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg140SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spdmisg140SelectListFilteres]
  @Filter_t_cprj VarChar(9),
  @Filter_t_resp VarChar(3),
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_docn VarChar(32) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_cprj'
  SET @LGSQL = @LGSQL + ', t_docn'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[tdmisg140200].[t_cprj]'
  SET @LGSQL = @LGSQL + ', [tdmisg140200].[t_docn]'
  SET @LGSQL = @LGSQL + ' FROM [tdmisg140200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_cprj > '') 
    SET @LGSQL = @LGSQL + ' AND [tdmisg140200].[t_cprj] = ''' + @Filter_t_cprj + ''''
  IF (@Filter_t_resp > '') 
    SET @LGSQL = @LGSQL + ' AND [tdmisg140200].[t_resp] = ''' + @Filter_t_resp + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_cprj' THEN '[tdmisg140200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[tdmisg140200].[t_cprj] DESC'
                        WHEN 't_docn' THEN '[tdmisg140200].[t_docn]'
                        WHEN 't_docn DESC' THEN '[tdmisg140200].[t_docn] DESC'
                        WHEN 't_revn' THEN '[tdmisg140200].[t_revn]'
                        WHEN 't_revn DESC' THEN '[tdmisg140200].[t_revn] DESC'
                        WHEN 't_dsca' THEN '[tdmisg140200].[t_dsca]'
                        WHEN 't_dsca DESC' THEN '[tdmisg140200].[t_dsca] DESC'
                        WHEN 't_cspa' THEN '[tdmisg140200].[t_cspa]'
                        WHEN 't_cspa DESC' THEN '[tdmisg140200].[t_cspa] DESC'
                        WHEN 't_resp' THEN '[tdmisg140200].[t_resp]'
                        WHEN 't_resp DESC' THEN '[tdmisg140200].[t_resp] DESC'
                        WHEN 't_lrrd' THEN '[tdmisg140200].[t_lrrd]'
                        WHEN 't_lrrd DESC' THEN '[tdmisg140200].[t_lrrd] DESC'
                        ELSE '[tdmisg140200].[t_cprj],[tdmisg140200].[t_docn]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [tdmisg140200].*  
  FROM [tdmisg140200] 
      INNER JOIN #PageIndex
          ON [tdmisg140200].[t_cprj] = #PageIndex.t_cprj
          AND [tdmisg140200].[t_docn] = #PageIndex.t_docn
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdwgHoldListSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdwgHoldListSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spdwgHoldListSelectByID]
  @LoginID NVarChar(8),
  @ProjectID NVarChar(6),
  @DocumentID NVarChar(25),
  @SerialNo Int 
  AS
  SELECT
    [DWG_HoldList].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [IDM_Projects2].[Description] AS IDM_Projects2_Description 
  FROM [DWG_HoldList] 
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [DWG_HoldList].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [DWG_HoldList].[ProjectID] = [IDM_Projects2].[ProjectID]
  WHERE
  [DWG_HoldList].[ProjectID] = @ProjectID
  AND [DWG_HoldList].[DocumentID] = @DocumentID
  AND [DWG_HoldList].[SerialNo] = @SerialNo
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdwgHoldListSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdwgHoldListSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spdwgHoldListSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
 ,DocumentID NVarChar(25) NOT NULL
 ,SerialNo Int NOT NULL
  )
  INSERT INTO #PageIndex (ProjectID, DocumentID, SerialNo)
  SELECT [DWG_HoldList].[ProjectID], [DWG_HoldList].[DocumentID], [DWG_HoldList].[SerialNo] FROM [DWG_HoldList]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [DWG_HoldList].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [DWG_HoldList].[ProjectID] = [IDM_Projects2].[ProjectID]
 WHERE  
   ( 
         STR(ISNULL([DWG_HoldList].[SerialNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[DocumentID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[RevisionAtHold],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[Description],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[Element],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[ResponsibleDept],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[PartUnderHold],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[ReasonForHold],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[RevisionAtUnhold],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[CreatedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([DWG_HoldList].[ProjectID],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'ProjectID' THEN [DWG_HoldList].[ProjectID] END,
     CASE @OrderBy WHEN 'ProjectID DESC' THEN [DWG_HoldList].[ProjectID] END DESC,
     CASE @OrderBy WHEN 'DocumentID' THEN [DWG_HoldList].[DocumentID] END,
     CASE @OrderBy WHEN 'DocumentID DESC' THEN [DWG_HoldList].[DocumentID] END DESC,
     CASE @OrderBy WHEN 'SerialNo' THEN [DWG_HoldList].[SerialNo] END,
     CASE @OrderBy WHEN 'SerialNo DESC' THEN [DWG_HoldList].[SerialNo] END DESC,
     CASE @OrderBy WHEN 'RevisionAtHold' THEN [DWG_HoldList].[RevisionAtHold] END,
     CASE @OrderBy WHEN 'RevisionAtHold DESC' THEN [DWG_HoldList].[RevisionAtHold] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [DWG_HoldList].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [DWG_HoldList].[Description] END DESC,
     CASE @OrderBy WHEN 'Element' THEN [DWG_HoldList].[Element] END,
     CASE @OrderBy WHEN 'Element DESC' THEN [DWG_HoldList].[Element] END DESC,
     CASE @OrderBy WHEN 'ResponsibleDept' THEN [DWG_HoldList].[ResponsibleDept] END,
     CASE @OrderBy WHEN 'ResponsibleDept DESC' THEN [DWG_HoldList].[ResponsibleDept] END DESC,
     CASE @OrderBy WHEN 'DateOfIssue' THEN [DWG_HoldList].[DateOfIssue] END,
     CASE @OrderBy WHEN 'DateOfIssue DESC' THEN [DWG_HoldList].[DateOfIssue] END DESC,
     CASE @OrderBy WHEN 'PartUnderHold' THEN [DWG_HoldList].[PartUnderHold] END,
     CASE @OrderBy WHEN 'PartUnderHold DESC' THEN [DWG_HoldList].[PartUnderHold] END DESC,
     CASE @OrderBy WHEN 'ReasonForHold' THEN [DWG_HoldList].[ReasonForHold] END,
     CASE @OrderBy WHEN 'ReasonForHold DESC' THEN [DWG_HoldList].[ReasonForHold] END DESC,
     CASE @OrderBy WHEN 'InputReceivedOn' THEN [DWG_HoldList].[InputReceivedOn] END,
     CASE @OrderBy WHEN 'InputReceivedOn DESC' THEN [DWG_HoldList].[InputReceivedOn] END DESC,
     CASE @OrderBy WHEN 'RevisionAtUnhold' THEN [DWG_HoldList].[RevisionAtUnhold] END,
     CASE @OrderBy WHEN 'RevisionAtUnhold DESC' THEN [DWG_HoldList].[RevisionAtUnhold] END DESC,
     CASE @OrderBy WHEN 'HoldRemovedIssued' THEN [DWG_HoldList].[HoldRemovedIssued] END,
     CASE @OrderBy WHEN 'HoldRemovedIssued DESC' THEN [DWG_HoldList].[HoldRemovedIssued] END DESC,
     CASE @OrderBy WHEN 'HoldStatus' THEN [DWG_HoldList].[HoldStatus] END,
     CASE @OrderBy WHEN 'HoldStatus DESC' THEN [DWG_HoldList].[HoldStatus] END DESC,
     CASE @OrderBy WHEN 'CreatedBy' THEN [DWG_HoldList].[CreatedBy] END,
     CASE @OrderBy WHEN 'CreatedBy DESC' THEN [DWG_HoldList].[CreatedBy] END DESC,
     CASE @OrderBy WHEN 'CreatedOn' THEN [DWG_HoldList].[CreatedOn] END,
     CASE @OrderBy WHEN 'CreatedOn DESC' THEN [DWG_HoldList].[CreatedOn] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC,
     CASE @OrderBy WHEN 'IDM_Projects2_Description' THEN [IDM_Projects2].[Description] END,
     CASE @OrderBy WHEN 'IDM_Projects2_Description DESC' THEN [IDM_Projects2].[Description] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [DWG_HoldList].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [IDM_Projects2].[Description] AS IDM_Projects2_Description 
  FROM [DWG_HoldList] 
      INNER JOIN #PageIndex
          ON [DWG_HoldList].[ProjectID] = #PageIndex.ProjectID
          AND [DWG_HoldList].[DocumentID] = #PageIndex.DocumentID
          AND [DWG_HoldList].[SerialNo] = #PageIndex.SerialNo
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [DWG_HoldList].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [DWG_HoldList].[ProjectID] = [IDM_Projects2].[ProjectID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdwgHoldListSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdwgHoldListSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spdwgHoldListSelectListFilteres]
  @Filter_DocumentID NVarChar(25),
  @Filter_ProjectID NVarChar(6),
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
 ,DocumentID NVarChar(25) NOT NULL
 ,SerialNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'ProjectID'
  SET @LGSQL = @LGSQL + ', DocumentID'
  SET @LGSQL = @LGSQL + ', SerialNo'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[DWG_HoldList].[ProjectID]'
  SET @LGSQL = @LGSQL + ', [DWG_HoldList].[DocumentID]'
  SET @LGSQL = @LGSQL + ', [DWG_HoldList].[SerialNo]'
  SET @LGSQL = @LGSQL + ' FROM [DWG_HoldList] '
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]'
  SET @LGSQL = @LGSQL + '    ON [DWG_HoldList].[CreatedBy] = [aspnet_users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects2]'
  SET @LGSQL = @LGSQL + '    ON [DWG_HoldList].[ProjectID] = [IDM_Projects2].[ProjectID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_DocumentID > '') 
    SET @LGSQL = @LGSQL + ' AND [DWG_HoldList].[DocumentID] = ''' + @Filter_DocumentID + ''''
  IF (@Filter_ProjectID > '') 
    SET @LGSQL = @LGSQL + ' AND [DWG_HoldList].[ProjectID] = ''' + @Filter_ProjectID + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'ProjectID' THEN '[DWG_HoldList].[ProjectID]'
                        WHEN 'ProjectID DESC' THEN '[DWG_HoldList].[ProjectID] DESC'
                        WHEN 'DocumentID' THEN '[DWG_HoldList].[DocumentID]'
                        WHEN 'DocumentID DESC' THEN '[DWG_HoldList].[DocumentID] DESC'
                        WHEN 'SerialNo' THEN '[DWG_HoldList].[SerialNo]'
                        WHEN 'SerialNo DESC' THEN '[DWG_HoldList].[SerialNo] DESC'
                        WHEN 'RevisionAtHold' THEN '[DWG_HoldList].[RevisionAtHold]'
                        WHEN 'RevisionAtHold DESC' THEN '[DWG_HoldList].[RevisionAtHold] DESC'
                        WHEN 'Description' THEN '[DWG_HoldList].[Description]'
                        WHEN 'Description DESC' THEN '[DWG_HoldList].[Description] DESC'
                        WHEN 'Element' THEN '[DWG_HoldList].[Element]'
                        WHEN 'Element DESC' THEN '[DWG_HoldList].[Element] DESC'
                        WHEN 'ResponsibleDept' THEN '[DWG_HoldList].[ResponsibleDept]'
                        WHEN 'ResponsibleDept DESC' THEN '[DWG_HoldList].[ResponsibleDept] DESC'
                        WHEN 'DateOfIssue' THEN '[DWG_HoldList].[DateOfIssue]'
                        WHEN 'DateOfIssue DESC' THEN '[DWG_HoldList].[DateOfIssue] DESC'
                        WHEN 'PartUnderHold' THEN '[DWG_HoldList].[PartUnderHold]'
                        WHEN 'PartUnderHold DESC' THEN '[DWG_HoldList].[PartUnderHold] DESC'
                        WHEN 'ReasonForHold' THEN '[DWG_HoldList].[ReasonForHold]'
                        WHEN 'ReasonForHold DESC' THEN '[DWG_HoldList].[ReasonForHold] DESC'
                        WHEN 'InputReceivedOn' THEN '[DWG_HoldList].[InputReceivedOn]'
                        WHEN 'InputReceivedOn DESC' THEN '[DWG_HoldList].[InputReceivedOn] DESC'
                        WHEN 'RevisionAtUnhold' THEN '[DWG_HoldList].[RevisionAtUnhold]'
                        WHEN 'RevisionAtUnhold DESC' THEN '[DWG_HoldList].[RevisionAtUnhold] DESC'
                        WHEN 'HoldRemovedIssued' THEN '[DWG_HoldList].[HoldRemovedIssued]'
                        WHEN 'HoldRemovedIssued DESC' THEN '[DWG_HoldList].[HoldRemovedIssued] DESC'
                        WHEN 'HoldStatus' THEN '[DWG_HoldList].[HoldStatus]'
                        WHEN 'HoldStatus DESC' THEN '[DWG_HoldList].[HoldStatus] DESC'
                        WHEN 'CreatedBy' THEN '[DWG_HoldList].[CreatedBy]'
                        WHEN 'CreatedBy DESC' THEN '[DWG_HoldList].[CreatedBy] DESC'
                        WHEN 'CreatedOn' THEN '[DWG_HoldList].[CreatedOn]'
                        WHEN 'CreatedOn DESC' THEN '[DWG_HoldList].[CreatedOn] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        WHEN 'IDM_Projects2_Description' THEN '[IDM_Projects2].[Description]'
                        WHEN 'IDM_Projects2_Description DESC' THEN '[IDM_Projects2].[Description] DESC'
                        ELSE '[DWG_HoldList].[ProjectID],[DWG_HoldList].[DocumentID],[DWG_HoldList].[SerialNo]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [DWG_HoldList].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [IDM_Projects2].[Description] AS IDM_Projects2_Description 
  FROM [DWG_HoldList] 
      INNER JOIN #PageIndex
          ON [DWG_HoldList].[ProjectID] = #PageIndex.ProjectID
          AND [DWG_HoldList].[DocumentID] = #PageIndex.DocumentID
          AND [DWG_HoldList].[SerialNo] = #PageIndex.SerialNo
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [DWG_HoldList].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects2]
    ON [DWG_HoldList].[ProjectID] = [IDM_Projects2].[ProjectID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdwgHoldListInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdwgHoldListInsert]
GO
 
CREATE PROCEDURE [dbo].[spdwgHoldListInsert]
  @DocumentID NVarChar(25),
  @RevisionAtHold NVarChar(32),
  @Description NVarChar(100),
  @Element NVarChar(8),
  @ResponsibleDept NVarChar(3),
  @DateOfIssue DateTime,
  @InputReceivedOn DateTime,
  @PartUnderHold NVarChar(50),
  @ReasonForHold NVarChar(50),
  @HoldRemovedIssued DateTime,
  @RevisionAtUnhold NVarChar(32),
  @HoldStatus Bit,
  @CreatedBy NVarChar(8),
  @CreatedOn DateTime,
  @ProjectID NVarChar(6),
  @Return_ProjectID NVarChar(6) = null OUTPUT, 
  @Return_DocumentID NVarChar(25) = null OUTPUT, 
  @Return_SerialNo Int = null OUTPUT 
  AS
  INSERT [DWG_HoldList]
  (
   [DocumentID]
  ,[RevisionAtHold]
  ,[Description]
  ,[Element]
  ,[ResponsibleDept]
  ,[DateOfIssue]
  ,[InputReceivedOn]
  ,[PartUnderHold]
  ,[ReasonForHold]
  ,[HoldRemovedIssued]
  ,[RevisionAtUnhold]
  ,[HoldStatus]
  ,[CreatedBy]
  ,[CreatedOn]
  ,[ProjectID]
  )
  VALUES
  (
   UPPER(@DocumentID)
  ,@RevisionAtHold
  ,@Description
  ,@Element
  ,@ResponsibleDept
  ,@DateOfIssue
  ,@InputReceivedOn
  ,@PartUnderHold
  ,@ReasonForHold
  ,@HoldRemovedIssued
  ,@RevisionAtUnhold
  ,@HoldStatus
  ,@CreatedBy
  ,@CreatedOn
  ,UPPER(@ProjectID)
  )
  SET @Return_ProjectID = @ProjectID
  SET @Return_DocumentID = @DocumentID
  SET @Return_SerialNo = Scope_Identity()
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdwgHoldListUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdwgHoldListUpdate]
GO
 
CREATE PROCEDURE [dbo].[spdwgHoldListUpdate]
  @Original_ProjectID NVarChar(6), 
  @Original_DocumentID NVarChar(25), 
  @Original_SerialNo Int, 
  @DocumentID NVarChar(25),
  @RevisionAtHold NVarChar(32),
  @Description NVarChar(100),
  @Element NVarChar(8),
  @ResponsibleDept NVarChar(3),
  @DateOfIssue DateTime,
  @InputReceivedOn DateTime,
  @PartUnderHold NVarChar(50),
  @ReasonForHold NVarChar(50),
  @HoldRemovedIssued DateTime,
  @RevisionAtUnhold NVarChar(32),
  @HoldStatus Bit,
  @CreatedBy NVarChar(8),
  @CreatedOn DateTime,
  @ProjectID NVarChar(6),
  @RowCount int = null OUTPUT
  AS
  UPDATE [DWG_HoldList] SET 
   [DocumentID] = @DocumentID
  ,[RevisionAtHold] = @RevisionAtHold
  ,[Description] = @Description
  ,[Element] = @Element
  ,[ResponsibleDept] = @ResponsibleDept
  ,[DateOfIssue] = @DateOfIssue
  ,[InputReceivedOn] = @InputReceivedOn
  ,[PartUnderHold] = @PartUnderHold
  ,[ReasonForHold] = @ReasonForHold
  ,[HoldRemovedIssued] = @HoldRemovedIssued
  ,[RevisionAtUnhold] = @RevisionAtUnhold
  ,[HoldStatus] = @HoldStatus
  ,[CreatedBy] = @CreatedBy
  ,[CreatedOn] = @CreatedOn
  ,[ProjectID] = @ProjectID
  WHERE
  [ProjectID] = @Original_ProjectID
  AND [DocumentID] = @Original_DocumentID
  AND [SerialNo] = @Original_SerialNo
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdwgHoldListDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdwgHoldListDelete]
GO
 
CREATE PROCEDURE [dbo].[spdwgHoldListDelete]
  @Original_ProjectID NVarChar(6),
  @Original_DocumentID NVarChar(25),
  @Original_SerialNo Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [DWG_HoldList]
  WHERE
  [DWG_HoldList].[ProjectID] = @Original_ProjectID
  AND [DWG_HoldList].[DocumentID] = @Original_DocumentID
  AND [DWG_HoldList].[SerialNo] = @Original_SerialNo
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
