USE [BookKeeping]
GO
/****** Object:  StoredProcedure [dbo].[p_DeleteUser]    Script Date: 7/27/2017 1:42:17 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[p_DeleteUser](
@id INTEGER
)

AS
BEGIN
SET NOCOUNT ON

DELETE FROM authority WHERE authority_id = @id

SET NOCOUNT OFF
END






GO
