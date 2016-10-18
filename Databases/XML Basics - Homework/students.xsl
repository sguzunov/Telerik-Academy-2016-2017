<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Students</title>
      </head>
      <body>
        <div class="students-section">
          <xsl:for-each select="/students/studnet">
            <div class="student">
              <label>Student name:</label>
              <span>
                <xsl:value-of select="name"></xsl:value-of>
              </span>
              <label>Speciality:</label>
              <span>
                <xsl:value-of select="speciality"></xsl:value-of>
              </span>
              <span>Exams:</span>
              <xsl:for-each select="/students/student/exams">
                <xsl:value-of select="name"></xsl:value-of>
              </xsl:for-each>
            </div>
          </xsl:for-each>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>