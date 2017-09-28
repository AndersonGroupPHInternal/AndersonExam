/*This requires both AndersonExam and AES database*/

/*AndersonExam.dbo.Exam*/
BEGIN
	SET IDENTITY_INSERT AndersonExam.dbo.Exam ON

	INSERT INTO AndersonExam.dbo.Exam
		(ExamId, TimeLimit, Name, Description, Instructions, Copyright, CreatedDate, CreatedBy, UpdatedDate, UpdatedBy)
	SELECT
		ExamID, ExamTimeLimit, ExamName, ExamDescription, ExamInstructions, Copyright, GETDATE(), 0, LastRevisedDate, 0
	FROM DbExams.dbo.tblExams
	WHERE ExamID NOT IN (SELECT ExamId FROM AndersonExam.dbo.Exam)

	SET IDENTITY_INSERT AndersonExam.dbo.Exam OFF
END

/*AndersonExam.dbo.Question*/
BEGIN
	SET IDENTITY_INSERT AndersonExam.dbo.Question ON

	INSERT INTO AndersonExam.dbo.Question
		(QuestionId, ExamId, Description, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		QuestionId, ExamId, QuestionItem, GETDATE(), 0, 0
	FROM DbExams.dbo.tblQuestions
	WHERE QuestionId NOT IN (SELECT QuestionId FROM AndersonExam.dbo.Question)

	SET IDENTITY_INSERT AndersonExam.dbo.Question OFF
END

/*AndersonExam.dbo.QuestionImage*/
BEGIN
	SET IDENTITY_INSERT AndersonExam.dbo.QuestionImage ON

	INSERT INTO AndersonExam.dbo.QuestionImage
		(QuestionImageId, QuestionId, Url, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		QuestionImageId, QuestionId, ImageUrl, GETDATE(), 0, 0
	FROM DbExams.dbo.tblQuestionImages
	WHERE QuestionImageId NOT IN (SELECT QuestionImageId FROM AndersonExam.dbo.QuestionImage)

	SET IDENTITY_INSERT AndersonExam.dbo.QuestionImage OFF
END

/*AndersonExam.dbo.Choice*/
BEGIN
	SET IDENTITY_INSERT AndersonExam.dbo.Choice ON

	INSERT INTO AndersonExam.dbo.Choice
		(Correct, ChoiceId, QuestionId, Description, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		Correct, ChoiceID, QuestionID, ChoiceItem, GETDATE(), 0, 0
	FROM DbExams.dbo.tblChoices
	WHERE ChoiceID NOT IN (SELECT ChoiceId FROM AndersonExam.dbo.Choice)

	SET IDENTITY_INSERT AndersonExam.dbo.Choice OFF
END

/*AndersonExam.dbo.ChoiceImage*/
BEGIN
	SET IDENTITY_INSERT AndersonExam.dbo.ChoiceImage ON

	INSERT INTO AndersonExam.dbo.ChoiceImage
		(ChoiceId, ChoiceImageId, Url, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		ChoiceID, ChoiceImageId, ImageUrl, GETDATE(), 0, 0
	FROM DbExams.dbo.tblChoiceImages
	WHERE ChoiceImageId NOT IN (SELECT ChoiceImageId FROM AndersonExam.dbo.ChoiceImage)

	SET IDENTITY_INSERT AndersonExam.dbo.ChoiceImage OFF
END

/*AndersonExam.dbo.Position*/
BEGIN
	SET IDENTITY_INSERT AndersonExam.dbo.Position ON

	INSERT INTO AndersonExam.dbo.Position
		(PositionId, Name, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		PositionId, PositionName, GETDATE(), 0, 0
	FROM DbExams.dbo.tblPositions
	WHERE PositionId NOT IN (SELECT PositionId FROM AndersonExam.dbo.Position)

	SET IDENTITY_INSERT AndersonExam.dbo.Position OFF
END

/*AndersonExam.dbo.ExamPosition*/
BEGIN
	INSERT INTO AndersonExam.dbo.ExamPosition
		(ExamId, PositionId, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		tblSetsOfTests.ExamId, tblPositions.PositionId, GETDATE(), 0, 0
	FROM
		DbExams.dbo.tblPositions
	INNER JOIN
		DbExams.dbo.tblPositionTestSets
			ON tblPositions.PositionId = tblPositionTestSets.PositionId
	INNER JOIN
		DbExams.dbo.tblSetsOfTests
			ON tblPositionTestSets.TestSetId = tblSetsOfTests.TestSetId
	WHERE NOT EXISTS (SELECT 1 FROM AndersonExam.dbo.ExamPosition WHERE ExamPosition.ExamId = tblSetsOfTests.ExamId AND ExamPosition.PositionId = tblPositions.PositionId)
		AND DbExams.dbo.tblSetsOfTests.ExamId In (SELECT ExamID from DbExams.dbo.TblExams)
	ORDER BY tblPositions.PositionId
END

/*AndersonExam.dbo.Examinee*/
BEGIN
	SET IDENTITY_INSERT AndersonExam.dbo.Examinee ON

	INSERT INTO AndersonExam.dbo.Examinee
		(ExamineeId, PositionId, ReferenceCode, Lastname, Firstname, Middlename, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		tblExaminees.ExamineeId, tblExamSets.PositionId, tblExaminees.ReferenceCode, Lastname, Firstname, Middlename, GETDATE(), 0, 0
	FROM DbExams.dbo.tblExaminees
	INNER JOIN DbExams.dbo.tblExamSets
		ON tblExaminees.ExamSetID = tblExamSets.ExamSetId
	WHERE tblExaminees.ExamineeId NOT IN (SELECT ExamineeId FROM AndersonExam.dbo.Examinee)

	SET IDENTITY_INSERT AndersonExam.dbo.Examinee OFF
END

/*AndersonExam.dbo.TakenExam*/
BEGIN
	INSERT INTO AndersonExam.dbo.TakenExam
		(ExamId, ExamineeId, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		ExamID, ExamineeID, GETDATE(), 0, 0
	FROM
		DbExams.dbo.tblAnswers
	WHERE NOT EXISTS (SELECT 1 FROM AndersonExam.dbo.TakenExam WHERE TakenExam.ExamId = tblAnswers.ExamId AND TakenExam.ExamineeId = tblAnswers.ExamineeID)
		AND ExamID IN (SELECT ExamId FROM AndersonExam.dbo.Exam)
		AND ExamineeID IN (SELECT ExamineeId FROM AndersonExam.dbo.Examinee)
	GROUP BY
		ExamID, ExamineeID
	ORDER BY ExamineeID
END

/*AndersonExam.dbo.Answer*/
BEGIN
	INSERT INTO AndersonExam.dbo.Answer
		(ChoiceId, QuestionId, TakenExamId, CreatedDate, CreatedBy, UpdatedBy)
	SELECT
		tblChoices.ChoiceID, tblAnswers.QuestionID, TakenExam.TakenExamId, GETDATE(), 0, 0
	FROM
		DbExams.dbo.tblAnswers
	INNER JOIN
		DbExams.dbo.tblChoices
			ON tblAnswers.AnswerItem = tblChoices.ChoiceItem
	INNER JOIN
		AndersonExam.dbo.TakenExam
			ON TakenExam.ExamId = tblAnswers.ExamId AND TakenExam.ExamineeId = tblAnswers.ExamineeID
	WHERE NOT EXISTS (SELECT 1 FROM AndersonExam.dbo.Answer WHERE Answer.ChoiceId = tblChoices.ChoiceID AND Answer.QuestionId = tblAnswers.QuestionID AND Answer.TakenExamId = TakenExam.TakenExamId)
		AND tblAnswers.ExamID IN (SELECT ExamId FROM AndersonExam.dbo.Exam)
		AND tblAnswers.ExamineeID IN (SELECT ExamineeId FROM AndersonExam.dbo.Examinee)
	ORDER BY 
		TakenExam.TakenExamId
END


