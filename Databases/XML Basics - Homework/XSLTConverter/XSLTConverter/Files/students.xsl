<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method='html' version='1.0' encoding='UTF-8' indent='yes' />
  <xsl:template match="/">
    <html>
      <head>
        <title>Students</title>
      </head>
      <body>
        <div class="students-section">
          <xsl:for-each select="students/student">
            <div class="student">
              <label>Student name:</label>
              <span>
                <xsl:value-of select="sex" />
              </span>
            </div>
          </xsl:for-each>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>